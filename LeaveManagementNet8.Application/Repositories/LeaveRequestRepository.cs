using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagementNet8.Application.Contracts;
using LeaveManagementNet8.Data;
using LeaveManagementNet8.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace LeaveManagementNet8.Application.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly AutoMapper.IConfigurationProvider _configProvider;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<Employee> _userManager;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmailSender _emailSender;

        public LeaveRequestRepository(
            ApplicationDbContext context,
            AutoMapper.IConfigurationProvider configProvider,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            UserManager<Employee> userManager,
            ILeaveAllocationRepository leaveAllocationRepository,
            ILeaveTypeRepository leaveTypeRepository,
            IEmployeeRepository employeeRepository,
            IEmailSender emailSender) : base(context)
        {
            _context = context;
            _configProvider = configProvider;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _employeeRepository = employeeRepository;
            _emailSender = emailSender;
        }

        public async Task CancelLeaveRequest(int leaveRequestId)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Cancelled = true;
            await UpdateAsync(leaveRequest);

            // Get the employee's Id to send the Email
            var user = await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);

            // Set the properties that where not provided by the user
            leaveRequest.LeaveType = await _leaveTypeRepository.GetAsync(leaveRequest.LeaveTypeId);

            await _emailSender.SendEmailAsync(user.Email, $"Demande de {leaveRequest.LeaveType.Name} annulée",
                $"Votre demande de {leaveRequest.LeaveType.Name} du " +
               $"{leaveRequest.StartDate.ToString("dd/MM/yyyy")} ({leaveRequest.StartTime})" +
               $" au {leaveRequest.EndDate.ToString("dd/MM/yyyy")} ({leaveRequest.EndTime})" +
               $" a été annulée avec succès.");
        }

        public async Task ChangeApprovalStatus(int leaveRequestId, bool approved)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Approved = approved;

            if(approved)
            {
                // Get the number of allocated days for this type of leave and for this employee
                var allocation = await _leaveAllocationRepository.GetEmployeeAllocation(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);
                double daysRequested = (double)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays + 1;
                allocation.NumberOfDays -= daysRequested;

                await _leaveAllocationRepository.UpdateAsync(allocation);
            }
            await UpdateAsync(leaveRequest);

            // Get the employee's Id to send the Email
            var user = await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);

            // Set the properties that where not provided by the user
            leaveRequest.LeaveType = await _leaveTypeRepository.GetAsync(leaveRequest.LeaveTypeId);

            var approvalStatus = approved ? "Approuvée" : "Rejetée";

            await _emailSender.SendEmailAsync(user.Email, $"Demande de {leaveRequest.LeaveType.Name} {approvalStatus}",
                $"Votre demande de {leaveRequest.LeaveType.Name} du " +
                $"{leaveRequest.StartDate.ToString("dd/MM/yyyy")} ({leaveRequest.StartTime})" +
                $" au {leaveRequest.EndDate.ToString("dd/MM/yyyy")} ({leaveRequest.EndTime})" +
                $" a été {approvalStatus}.");
        }

        public async Task<bool> CreateLeaveRequest(LeaveRequestCreateVM model)
        {
            // Get the employee's info to allocate him the requested leave days
            var user = await _userManager.GetUserAsync(_httpContextAccessor?.HttpContext?.User);

            var leaveAllocation = await _leaveAllocationRepository.GetEmployeeAllocation(user.Id, model.LeaveTypeId);

            if(leaveAllocation == null) 
            {
                return false;
            }

            double daysRequested = (double)(model.EndDate.Value - model.StartDate.Value).TotalDays + 1;

            if (daysRequested > leaveAllocation.NumberOfDays) 
            {
                return false;
            }

            var leaveRequest = _mapper.Map<LeaveRequest>(model);

            // Set the properties that where not provided by the user
            leaveRequest.DateModified = DateTime.UtcNow;
            leaveRequest.RequestingEmployeeId = user.Id;
            leaveRequest.LeaveType = await _leaveTypeRepository.GetAsync(leaveRequest.LeaveTypeId);

            await AddAsync(leaveRequest);

            await _emailSender.SendEmailAsync(user.Email, $"Demande de {leaveRequest.LeaveType.Name} soumise pour approbation",
                $"Votre demande de {leaveRequest.LeaveType.Name} du " +
                $"{leaveRequest.StartDate.ToString("dd/MM/yyyy")} ({leaveRequest.StartTime})" +
                $" au {leaveRequest.EndDate.ToString("dd/MM/yyyy")} ({leaveRequest.EndTime})" +
                $" a été soumise pour approbation.");

            var supervisorId = user.SupervisorId;
            var supervisor = await _employeeRepository.GetEmployeeByIdAsync(supervisorId);

            await _emailSender.SendEmailAsync(supervisor.Email, $"Demande de {leaveRequest.LeaveType.Name} soumise pour approbation",
                $"Une demande de {leaveRequest.LeaveType.Name} du " +
                $"{leaveRequest.StartDate.ToString("dd/MM/yyyy")} ({leaveRequest.StartTime})" +
                $" au {leaveRequest.EndDate.ToString("dd/MM/yyyy")} ({leaveRequest.EndTime})" +
                $" a été soumise par {user.FirstName} {user.LastName} pour approbation.");

            return true;
        }

        public async Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList()
        {
            var leaveRequests = await _context.LeaveRequests.Include(q => q.LeaveType).ToListAsync();
            var model = new AdminLeaveRequestViewVM
            {
                TotalRequests = leaveRequests.Count,
                ApprovedRequests = leaveRequests.Count(q => q.Approved == true),
                RejectedRequests = leaveRequests.Count(q => q.Approved == false),
                PendingRequests = leaveRequests.Count(q => q.Approved == null),
                LeaveRequests = _mapper.Map<List<LeaveRequestVM>>(leaveRequests)
            };

            foreach (var leaveRequest in model.LeaveRequests)
            {
                leaveRequest.Employee =  _mapper.Map<EmployeeListVM>(await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId));   
            }

            return model;
        }

        public async Task<AdminLeaveRequestViewVM> GetLeaveRequestBySupervisorId(string supervisorId)
        {
            // Get all employees associated to the Supervisor
            var employees = await _employeeRepository.GetEmployeesBySupervisorId(supervisorId);

            // Get all Leave Requests for these employees
            var TeamleaveRequests = new List<LeaveRequestVM>();
            var singleEmployeeRequests = new List<LeaveRequestVM>();

            foreach (var employee in employees)
            {
                singleEmployeeRequests = await this.GetAllAsync(employee.Id);
                TeamleaveRequests.AddRange(singleEmployeeRequests);
            }

            // Add statistics to the dashboard
            var model = new AdminLeaveRequestViewVM
            {
                TotalRequests = TeamleaveRequests.Count,
                ApprovedRequests = TeamleaveRequests.Count(q => q.Approved == true),
                RejectedRequests = TeamleaveRequests.Count(q => q.Approved == false),
                PendingRequests = TeamleaveRequests.Count(q => q.Approved == null),
                LeaveRequests = TeamleaveRequests
            };

            // Get info from the requesting users
            foreach (var leaveRequest in model.LeaveRequests)
            {
                leaveRequest.Employee = _mapper.Map<EmployeeListVM>(await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId));
            }

            return model;

        }

        public async Task<List<LeaveRequestVM>> GetAllAsync(string employeeId)
        {
           return await _context.LeaveRequests
                .Include(q => q.LeaveType)
                .Where(q =>q.RequestingEmployeeId == employeeId)
                .ProjectTo<LeaveRequestVM>(_configProvider)
                .ToListAsync();
        }

        public async Task<LeaveRequestVM?> GetLeaveRequestAsync(int? id)
        {
            var leaveRequest = await _context.LeaveRequests
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);

            if(leaveRequest == null)
            {
                return null;
            }

            var model = _mapper.Map<LeaveRequestVM>(leaveRequest);
            model.Employee = _mapper.Map<EmployeeListVM>(await _userManager.FindByIdAsync(leaveRequest?.RequestingEmployeeId));

            return model;
        }

        public async Task<EmployeeLeaveRequestViewVM> GetMyLeavetDetails()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor?.HttpContext?.User);
            var allocations = (await _leaveAllocationRepository.GetEmployeeAllocations(user.Id)).leaveAllocations;
            var requests =await GetAllAsync(user.Id);

            var model = new EmployeeLeaveRequestViewVM(allocations, requests);
            
            return model;
        }
    }
}

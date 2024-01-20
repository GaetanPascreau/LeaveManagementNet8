using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagementNet8.Application.Contracts;
using LeaveManagementNet8.Data;
using LeaveManagementNet8.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using LeaveManagementNet8.Common.Constants;

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

        // Define holidays for the current Year
        List<DateTime> holidays = new List<DateTime>
        {
            new DateTime(2024, 01, 01), // Jour de l'an
            new DateTime(2024, 04, 01), // Lundi de Pâques
            new DateTime(2024, 05, 01), // Fête du travail
            new DateTime(2024, 05, 08), // Armistice 1945
            new DateTime(2024, 05, 09), // Jeudi de l'Ascension
            new DateTime(2024, 05, 20), // Lundi de Pentecôte
            new DateTime(2024, 07, 14), // Fête Nationale
            new DateTime(2024, 08, 15), // Assomption
            new DateTime(2024, 11, 01), // Toussaint
            new DateTime(2024, 11, 11), // Armistice 1918
            new DateTime(2024, 12, 25)  // Noël
        };

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
            double leaveDays = 0;

            if(approved)
            {
                // Get the number of allocated days for this type of leave and for this employee
                var allocation = await _leaveAllocationRepository.GetEmployeeAllocation(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);

                // Get the number of full days, without the weekends and holidays
                for (DateTime date = (DateTime)leaveRequest.StartDate; date <= leaveRequest.EndDate; date = date.AddDays(1))
                {
                    if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday && !holidays.Contains(date))
                    {
                        leaveDays++;
                    }
                }

                // Taking half days into account
                if (leaveRequest.StartTime == DayTime.Afternoon && leaveRequest.EndTime == DayTime.Afternoon)
                {
                    leaveDays -= 0.5;
                }
                else if (leaveRequest.StartTime == DayTime.Morning && leaveRequest.EndTime == DayTime.Morning)
                {
                    leaveDays -= 0.5;
                }
                else if (leaveRequest.StartTime == DayTime.Afternoon && leaveRequest.EndTime == DayTime.Morning)
                {
                    leaveDays -= 1;
                }

                // Update the number of remaining available Leave Days, according to the number of approved Leave Days
                allocation.NumberOfDays -= leaveDays;
                await _leaveAllocationRepository.UpdateAsync(allocation);
            }
            await UpdateAsync(leaveRequest);

            // Get the employee's Id to send the Email
            var user = await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);

            // Set the properties that where not provided by the user
            leaveRequest.LeaveType = await _leaveTypeRepository.GetAsync(leaveRequest.LeaveTypeId);

            // Define the text to display in the Email's title, according to the status of the Leave Request
            var approvalStatus = approved ? "Approuvée" : "Rejetée";

            await _emailSender.SendEmailAsync(user.Email, $"Demande de {leaveRequest.LeaveType.Name} {approvalStatus}",
                $"Votre demande de {leaveRequest.LeaveType.Name} du " +
                $"{leaveRequest.StartDate.ToString("dd/MM/yyyy")} ({leaveRequest.StartTime})" +
                $" au {leaveRequest.EndDate.ToString("dd/MM/yyyy")} ({leaveRequest.EndTime})" +
                $" ({leaveDays} jours)" +
                $" a été {approvalStatus}.");
        }

        public async Task<bool> CreateLeaveRequest(LeaveRequestCreateVM model)
        {
            // Get the employee's info to allocate him the requested leave days
            var user = await _userManager.GetUserAsync(_httpContextAccessor?.HttpContext?.User);

            // Get the number of remaining allocated days for a given employee
            var leaveAllocation = await _leaveAllocationRepository.GetEmployeeAllocation(user.Id, model.LeaveTypeId);

            if (leaveAllocation == null) 
            {
                return false;
            }

            // A Leave cannot start or finish on a weekend or an holiday  (!! can't we validate this directly on the form from the UI ?)
            // en l'état si on entre dans ce if => on a le message d'erreur générique "Vous avez dépassé votre allocation avec cette demande", ce qui est faux
            // il faut revoir cette validation
            if (model.StartDate.Value.DayOfWeek == DayOfWeek.Saturday ||
                model.StartDate.Value.DayOfWeek == DayOfWeek.Sunday ||
                model.EndDate.Value.DayOfWeek == DayOfWeek.Saturday ||
                model.EndDate.Value.DayOfWeek == DayOfWeek.Sunday ||
                holidays.Contains(model.StartDate.Value) ||
                holidays.Contains(model.EndDate.Value))
            {
                return false;
            }

            // Get the number of full days, without the weekends and holydays
            double leaveDays = 0;
            for (DateTime date = (DateTime)model.StartDate; date <= model.EndDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday && !holidays.Contains(date))
                {
                    leaveDays++;
                }
            }

            // Taking half days into account
            if (model.StartTime == DayTime.Afternoon && model.EndTime == DayTime.Afternoon)
            {
                leaveDays -= 0.5;
            }
            else if (model.StartTime == DayTime.Morning && model.EndTime == DayTime.Morning)
            {
                leaveDays -= 0.5;
            }
            else if (model.StartTime == DayTime.Afternoon && model.EndTime == DayTime.Morning)
            {
                leaveDays -= 1;
            }

            // Check that le number of requested days doesn't exceed the number of remaining allocated days
            if (leaveDays > leaveAllocation.NumberOfDays)
            {
                return false;
            }

            var leaveRequest = _mapper.Map<LeaveRequest>(model);

            // Set the properties that where not provided by the user
            leaveRequest.DateModified = DateTime.UtcNow;
            leaveRequest.RequestingEmployeeId = user.Id;
            leaveRequest.LeaveType = await _leaveTypeRepository.GetAsync(leaveRequest.LeaveTypeId);
            leaveRequest.DateRequested = DateTime.UtcNow;
            leaveRequest.RequestedDaysNumber = leaveDays;
            

            await AddAsync(leaveRequest);

            await _emailSender.SendEmailAsync(user.Email, $"Demande de {leaveRequest.LeaveType.Name} soumise pour approbation",
                $"Votre demande de {leaveRequest.LeaveType.Name} du " +
                $"{leaveRequest.StartDate.ToString("dd/MM/yyyy")} ({leaveRequest.StartTime})" +
                $" au {leaveRequest.EndDate.ToString("dd/MM/yyyy")} ({leaveRequest.EndTime})" +
                $" ({leaveDays} jours)" +
                $" a été soumise pour approbation.");

            var supervisorId = user.SupervisorId;
            var supervisor = await _employeeRepository.GetEmployeeByIdAsync(supervisorId);

            await _emailSender.SendEmailAsync(supervisor.Email, $"Demande de {leaveRequest.LeaveType.Name} soumise pour approbation",
                $"Une demande de {leaveRequest.LeaveType.Name} du " +
                $"{leaveRequest.StartDate.ToString("dd/MM/yyyy")} ({leaveRequest.StartTime})" +
                $" au {leaveRequest.EndDate.ToString("dd/MM/yyyy")} ({leaveRequest.EndTime})" +
                $" ({leaveDays} jours)" +
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

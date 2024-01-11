using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagementNet8.Common.Constants;
using LeaveManagementNet8.Application.Contracts;
using LeaveManagementNet8.Data;
using LeaveManagementNet8.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementNet8.Application.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly AutoMapper.IConfigurationProvider _configurationProvider;
        private readonly IMapper _mapper;
        private readonly UserManager<Employee> _userManager;
        private readonly IEmailSender _emailSender;

        public LeaveAllocationRepository(
            ApplicationDbContext context,
            ILeaveTypeRepository leaveTypeRepository,
            AutoMapper.IConfigurationProvider configurationProvider,
            IMapper mapper,
            UserManager<Employee> userManager,
            IEmailSender emailSender) : base(context)
        {
            _context = context;
            _leaveTypeRepository = leaveTypeRepository;
            _configurationProvider = configurationProvider;
            _mapper = mapper;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public async Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period)
        {
            return  await _context.LeaveAllocations.AnyAsync(q => q.EmployeeId == employeeId
                                                                    && q.LeaveTypeId == leaveTypeId
                                                                    && q.Period == period);
        }

        public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string employeeId)
        {
            var allocations = await _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .Where(q => q.EmployeeId == employeeId)
                .ProjectTo<LeaveAllocationVM>(_configurationProvider)
                .ToListAsync();

            var employee = await _userManager.FindByIdAsync(employeeId);

            var employeeAllocationModel = _mapper.Map<EmployeeAllocationVM>(employee);
            employeeAllocationModel.leaveAllocations = allocations;

            return employeeAllocationModel;
        }

        public async Task<LeaveAllocationEditVM> GetEmployeeAllocation(int id)
        { 
            var allocationModel = await _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .ProjectTo<LeaveAllocationEditVM>(_configurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (allocationModel == null)
            {
                return null;
            }

            var employee = await _userManager.FindByIdAsync(allocationModel.EmployeeId);

            allocationModel.Employee = _mapper.Map<EmployeeListVM>(employee);

            return allocationModel;
        }

        public async Task LeaveAllocation(int leaveTypeId)
        {
            // Get the list of employees, the Leave Type, set the period for the Leave Allocation, and Create a list of Leave Allocations
            var employees = await _userManager.GetUsersInRoleAsync(Roles.User);
            var leaveType = await _leaveTypeRepository.GetAsync(leaveTypeId);
            var period = DateTime.Now.Year;
            var allocations = new List<LeaveAllocation>();
            var employeeWithNewLeaveAllocations = new List<Employee>();

            // Add Allocation for each employee into the list of allocations, only if it doesn't already exists
            foreach (var employee in employees)
            {
                if (await AllocationExists(employee.Id, leaveTypeId, period))
                {
                    continue;
                }

                allocations.Add(new LeaveAllocation
                {
                    EmployeeId = employee.Id,
                    LeaveTypeId = leaveTypeId,
                    Period = period,
                    NumberOfDays = leaveType.DefaultDays
                });

                employeeWithNewLeaveAllocations.Add(employee);
            }

            await AddRangeAsync(allocations);

            foreach (var employee in employeeWithNewLeaveAllocations) 
            {
                await _emailSender.SendEmailAsync(employee.Email, $"Leave Allocation Posted for {period}", $"Your {leaveType.Name} " +
                $"has been posted for the period of {period}. You have been given {leaveType.DefaultDays} days.");
            }
        }

        public async Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditVM model)
        {
            var leaveAllocation = await GetAsync(model.Id);

            if (leaveAllocation == null)
            {
                return false;
            }

            leaveAllocation.Period = model.Period;
            leaveAllocation.NumberOfDays = model.NumberOfDays;
            await UpdateAsync(leaveAllocation);

            return true;
        }

        public async Task<LeaveAllocation?> GetEmployeeAllocation(string employeeId, int leaveTypeId)
        {
            return await _context.LeaveAllocations.FirstOrDefaultAsync(q => q.EmployeeId == employeeId && q.LeaveTypeId == leaveTypeId);
        }
    }
}
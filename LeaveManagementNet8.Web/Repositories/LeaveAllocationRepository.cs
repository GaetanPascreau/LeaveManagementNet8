using AutoMapper;
using LeaveManagementNet8.Web.Constants;
using LeaveManagementNet8.Web.Contracts;
using LeaveManagementNet8.Web.Data;
using LeaveManagementNet8.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementNet8.Web.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<Employee> _userManager;

        public LeaveAllocationRepository(
            ApplicationDbContext context,
            ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper,
            UserManager<Employee> userManager) : base(context)
        {
            _context = context;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period)
        {
            return  await _context.LeaveAllocations.AnyAsync(q => q.EmployeeId == employeeId && q.LeaveTypeId == leaveTypeId && q.Period == period);
        }

        public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string employeeId)
        {
            var allocations = await _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .Where(q => q.EmployeeId == employeeId).ToListAsync();

            var employee = await _userManager.FindByIdAsync(employeeId);

            var employeeAllocationModel = _mapper.Map<EmployeeAllocationVM>(employee);
            employeeAllocationModel.leaveAllocations = _mapper.Map<List<LeaveAllocationVM>>(allocations);

            return employeeAllocationModel;
        }

        public async Task<LeaveAllocationEditVM> GetEmployeeAllocation(int id)
        { 
            var allocation = await _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (allocation == null)
            {
                return null;
            }

            var employee = await _userManager.FindByIdAsync(allocation.EmployeeId);

            var model = _mapper.Map<LeaveAllocationEditVM>(allocation);
            model.Employee = _mapper.Map<EmployeeListVM>(employee);

            return model;
        }

        public async Task LeaveAllocation(int leaveTypeId)
        {
            // Get the list of employees, the Leave Type, set the period for the Leave Allocation, and Create a list of Leave Allocations
            var employees = await _userManager.GetUsersInRoleAsync(Roles.User);
            var leaveType = await _leaveTypeRepository.GetAsync(leaveTypeId);
            var period = DateTime.Now.Year;
            var allocations = new List<LeaveAllocation>();

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
            }

            await AddRangeAsync(allocations);
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
    }
}
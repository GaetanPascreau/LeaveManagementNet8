using LeaveManagementNet8.Application.Contracts;
using LeaveManagementNet8.Data;

namespace LeaveManagementNet8.Application.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

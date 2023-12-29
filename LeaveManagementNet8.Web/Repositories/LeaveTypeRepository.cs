using LeaveManagementNet8.Web.Contracts;
using LeaveManagementNet8.Web.Data;

namespace LeaveManagementNet8.Web.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

using LeaveManagementNet8.Web.Data;
using LeaveManagementNet8.Web.Models;

namespace LeaveManagementNet8.Web.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<bool> CreateLeaveRequest(LeaveRequestCreateVM model);
        Task<List<LeaveRequestVM>> GetAllAsync(string employeeId);
        Task<EmployeeLeaveRequestViewVM> GetMyLeavetDetails();
        Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList();
        Task ChangeApprovalStatus(int leaveRequestId, bool approved);
        Task<LeaveRequestVM?> GetLeaveRequestAsync(int? id);
        Task CancelLeaveRequest(int leaveRequestId);
    }
}

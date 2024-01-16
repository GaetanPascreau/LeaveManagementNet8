using LeaveManagementNet8.Data;
using LeaveManagementNet8.Common.Models;

namespace LeaveManagementNet8.Application.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<bool> CreateLeaveRequest(LeaveRequestCreateVM model);
        Task<List<LeaveRequestVM>> GetAllAsync(string employeeId);
        Task<EmployeeLeaveRequestViewVM> GetMyLeavetDetails();
        Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList();
        Task<AdminLeaveRequestViewVM> GetLeaveRequestBySupervisorId(string supervisorId);
        Task ChangeApprovalStatus(int leaveRequestId, bool approved);
        Task<LeaveRequestVM?> GetLeaveRequestAsync(int? id);
        Task CancelLeaveRequest(int leaveRequestId);
    }
}

using LeaveManagementNet8.Data;

namespace LeaveManagementNet8.Application.Contracts
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<Employee> GetEmployeeByIdAsync(string id);
        Task<List<Employee>> GetEmployeesBySupervisorId (string supervisorId);
    }
}

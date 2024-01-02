using System.ComponentModel.DataAnnotations;

namespace LeaveManagementNet8.Web.Models
{
    public class EmployeeAllocationVM : EmployeeListVM
    {
        public List<LeaveAllocationVM> leaveAllocations { get; set; }
    }
}

using LeaveManagementNet8.Web.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace LeaveManagementNet8.Web.Models
{
    public class LeaveRequestVM : LeaveRequestCreateVM
    {
        public int Id { get; set; }

        [Display(Name = "Date Requested")]
        public DateTime DateRequested { get; set; }

        [Display(Name = "Leave Type")]
        public LeaveTypeVM LeaveType { get; set; }

        [Display(Name = "Approval Status")]
        public bool? Approved { get; set; }

        public bool Cancelled { get; set; }

        public string? RequestingEmployeeId { get; set; }

        public EmployeeListVM Employee {  get; set; }
    }
}

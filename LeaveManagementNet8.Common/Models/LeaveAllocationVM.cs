using System.ComponentModel.DataAnnotations;

namespace LeaveManagementNet8.Common.Models
{
    public class LeaveAllocationVM
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Number Of Days")]
        [Required]
        [Range(1,50, ErrorMessage = "Invalid Number Entered")]
        public int NumberOfDays { get; set; }

        [Display(Name = "Allocation Period")]
        [Required]
        public int Period { get; set; }

        public LeaveTypeVM? LeaveType { get; set; }
    }
}
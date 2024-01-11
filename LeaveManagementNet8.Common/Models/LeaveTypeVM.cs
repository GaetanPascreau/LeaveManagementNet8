using System.ComponentModel.DataAnnotations;

namespace LeaveManagementNet8.Common.Models
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }

        [Display(Name = "Leave Type Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Default Number Of Days")]
        [Required]
        [Range(1,25, ErrorMessage = "Please enter a valid number.")]
        public int DefaultDays { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace LeaveManagementNet8.Common.Models
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }

        [Display(Name = "Type de congés")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Nombre de jours par défaut")]
        [Required]
        [Range(1,25, ErrorMessage = "Veuillez entrer un nombre valide.")]
        public double DefaultDays { get; set; }
    }
}

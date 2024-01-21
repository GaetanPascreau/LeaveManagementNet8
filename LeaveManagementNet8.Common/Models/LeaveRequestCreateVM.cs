using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementNet8.Common.Models
{
    public class LeaveRequestCreateVM : IValidatableObject
    {
        [Required]
        [Display(Name = "Date de début")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Veuillez choisir une heure de début.")]
        [Display(Name = "Heure de début")]
        public string StartTime { get; set; }

        [Required]
        [Display(Name = "Date de fin")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Veuillez choisir une heure de fin.")]
        [Display(Name = "Heure de fin")]
        public string EndTime { get; set; }

        [Required(ErrorMessage = "Veuillez sélectionner un type de congés.")]
        [Display(Name = "Type de congés")]
        public int LeaveTypeId { get; set; }
        public SelectList? LeaveTypes { get; set; }

        [Display(Name = "Commentaires")]
        public string? RequestComments { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate > EndDate)
            {
                yield return new ValidationResult("La date de début doit être antérieure à la date de fin.",
                    new[] { nameof(StartDate), nameof(EndDate) });
            }

            if (RequestComments?.Length > 250)
            {
                yield return new ValidationResult("Le commentaire est trop long.",
                    new[] { nameof(RequestComments) });
            }
        }
    }
}

﻿using System.ComponentModel.DataAnnotations;

namespace LeaveManagementNet8.Common.Models
{
    public class EmployeeListVM
    {
        public string Id { get; set; }


        [Display(Name = "Prénom")] 
        public string FirstName { get; set; }

        [Display(Name = "Nom")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Date d'embauche")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime DateJoined {  get; set; }    
    }
}

using System.ComponentModel.DataAnnotations;

namespace LeaveManagementNet8.Common.Models
{
    public class AdminLeaveRequestViewVM
    {
        [Display(Name = "Nombre Total De Demandes")]
        public double TotalRequests { get; set; }

        [Display(Name = "Demandes Approuvées")]
        public double ApprovedRequests { get; set; }

        [Display(Name = "Demandes En Attente")]
        public double PendingRequests { get; set; }

        [Display(Name = "Demandes Rejetées")]
        public double RejectedRequests { get; set; }

        public List<LeaveRequestVM> LeaveRequests { get; set; }
    }
}

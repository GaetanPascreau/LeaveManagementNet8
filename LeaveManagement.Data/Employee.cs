using Microsoft.AspNetCore.Identity;

namespace LeaveManagementNet8.Data
{
    public class Employee : IdentityUser
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? FullName { get; set; }

        public string? TaxId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateJoined { get; set; }

        public string? SupervisorId { get; set; }

        public string? Employer { get; set; }
    }
}

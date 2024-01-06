using LeaveManagementNet8.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementNet8.Web.Configurations.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            var hasher = new PasswordHasher<Employee>();
            builder.HasData(
                new Employee
                {
                    Id = "2b4e9f30-05e5-49af-b472-3fd878bad75f",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    FirstName = "System",
                    LastName = "Admin",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true,
                },
                new Employee
                {
                    Id = "83703abf-0de1-44ba-b92d-00761bd419ef",
                    Email = "user@localhost.com",
                    NormalizedEmail = "USER@LOCALHOST.COM",
                    UserName = "user@localhost.com",
                    NormalizedUserName = "USER@LOCALHOST.COM",
                    FirstName = "System",
                    LastName = "User",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true,
                },
                new Employee
                {
                    Id = "3d6189cb-6a27-458a-8155-fd368df24eef",
                    Email = "supervisor@localhost.com",
                    NormalizedEmail = "SUPERVISOR@LOCALHOST.COM",
                    UserName = "supervisor@localhost.com",
                    NormalizedUserName = "SUPERVISOR@LOCALHOST.COM",
                    FirstName = "System",
                    LastName = "Supervisor",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true,
                }
            );
        }
    }
}
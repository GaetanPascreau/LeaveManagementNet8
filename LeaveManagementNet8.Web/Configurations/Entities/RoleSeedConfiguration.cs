using LeaveManagementNet8.Web.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementNet8.Web.Configurations.Entities
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "49552dc4-be6e-4b84-90a9-18043bfd5fa9",
                    Name = Roles.Administrator,
                    NormalizedName = Roles.Administrator.ToUpper(),
                },
                new IdentityRole
                {
                    Id = "2c42045b-0c7d-4899-8b85-1ae7c0408f86",
                    Name = Roles.User,
                    NormalizedName = Roles.User.ToUpper(),
                },
                new IdentityRole
                {
                    Id = "ee994451-0e37-44d3-8636-c7f778bcb9f3",
                    Name = Roles.Supervisor,
                    NormalizedName = Roles.Supervisor.ToUpper()
                }
            );
        }
    }
}
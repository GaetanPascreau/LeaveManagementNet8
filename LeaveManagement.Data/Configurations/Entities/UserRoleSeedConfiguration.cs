using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementNet8.Data.Configurations.Entities
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "49552dc4-be6e-4b84-90a9-18043bfd5fa9",
                    UserId = "2b4e9f30-05e5-49af-b472-3fd878bad75f"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "2c42045b-0c7d-4899-8b85-1ae7c0408f86",
                    UserId = "83703abf-0de1-44ba-b92d-00761bd419ef"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "ee994451-0e37-44d3-8636-c7f778bcb9f3",
                    UserId = "3d6189cb-6a27-458a-8155-fd368df24eef"
                }
            );
        }
    }
}
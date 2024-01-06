using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementNet8.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedRequestComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b4e9f30-05e5-49af-b472-3fd878bad75f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f20e9e97-e060-4134-a7b8-8fa69e6b047a", "AQAAAAIAAYagAAAAEDZVWa2Bqx7/cRcEqkG+EhGKvsr6lT30gCRJcpOEnFPXKKtdcMyg/moN4m6x8ffZhQ==", "ad1e9905-13cc-4dd1-87aa-8bce49f9aabd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d6189cb-6a27-458a-8155-fd368df24eef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8fb9eb55-963c-4227-8c46-0e60f7da15df", "AQAAAAIAAYagAAAAEIAvRT/r1ZgkLO2H4NLJhHUCvYiJ+ljoGfLsxm9OY0YK/ROLGRGFhVCqFAt3avVDIw==", "39c6217e-b219-4365-b65a-23033c445e93" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83703abf-0de1-44ba-b92d-00761bd419ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03acfa54-351b-435c-b1b4-0d6670623ffb", "AQAAAAIAAYagAAAAEBq0u2+AuONq7OsscxoptWNl18l3voL14RegX1rot9rLxZJh7wQESfz6SJqf0m9Fjg==", "27ae8f6a-27cc-4df8-8959-b31640b28ecc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b4e9f30-05e5-49af-b472-3fd878bad75f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68f4287d-a744-495e-af83-ec31387aecbf", "AQAAAAIAAYagAAAAEEyQoCkovAIz+DOBmW0Yc7Mv1AI0EfbW8EaiHTZN5XMpvM5ELUNRDWJZiYTaBzzgEg==", "3010f00b-5d9a-4204-a6df-c1c44de4337a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d6189cb-6a27-458a-8155-fd368df24eef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9271b174-01a0-4bdd-959d-f08f7f4d0821", "AQAAAAIAAYagAAAAEAU60BN+DgyeVImFGDQfCokJG92OG4a36UPmkoo2NSNgCYymKc/GGalq61TOOfQq2w==", "f05314bd-74bd-49e4-9189-3cea30cc22f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83703abf-0de1-44ba-b92d-00761bd419ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd8a172f-1112-4101-ad43-ec4eb9edc0e8", "AQAAAAIAAYagAAAAELVK1uv53EbwIJ9xx8TeKzXQiJvexD+jxWADRKt8s4nZRhLHKZsJEUsO9NUgSmoZ2Q==", "6bcbd01b-5f09-4afb-b704-bd2beff429e1" });
        }
    }
}

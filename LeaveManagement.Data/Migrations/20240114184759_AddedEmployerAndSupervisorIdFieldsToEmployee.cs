using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementNet8.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedEmployerAndSupervisorIdFieldsToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Employer",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupervisorId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b4e9f30-05e5-49af-b472-3fd878bad75f",
                columns: new[] { "ConcurrencyStamp", "Employer", "PasswordHash", "SecurityStamp", "SupervisorId" },
                values: new object[] { "6159cc07-a5fb-4757-b201-bce083975922", "Sogescot", "AQAAAAIAAYagAAAAEDL24+HMSZFsNj1wTV+1bMkcafM5Uw9Zes6QoVeS4YYbYvIJqV3gIJb9AgjYdjYAlg==", "c1b95d86-55ea-4176-bee8-fee09b762842", "2b4e9f30-05e5-49af-b472-3fd878bad75f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d6189cb-6a27-458a-8155-fd368df24eef",
                columns: new[] { "ConcurrencyStamp", "Employer", "PasswordHash", "SecurityStamp", "SupervisorId" },
                values: new object[] { "93cbc128-261f-44f1-81c3-8f2086a2f4b2", "Sogescot", "AQAAAAIAAYagAAAAEAvhTCXCYT87M0/5giM5BfDjb2z9l33dzCAxU7umdUtmS+mXTxtiTp74AhFUbMapRg==", "3c2ef962-20fa-42e6-98af-ee1c68a913d5", "2b4e9f30-05e5-49af-b472-3fd878bad75f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83703abf-0de1-44ba-b92d-00761bd419ef",
                columns: new[] { "ConcurrencyStamp", "Employer", "PasswordHash", "SecurityStamp", "SupervisorId" },
                values: new object[] { "c057069a-2d03-49a7-babe-abcd265dd0bb", "Sogescot", "AQAAAAIAAYagAAAAEHBrE0h7vin9db+BXFC1ifVhTObOTc/beQVE9gSjoWK7j/bOu4o0I4AZCklXFNePVQ==", "fd2f1dce-35fd-4ae9-affd-94ad5be28d2a", "3d6189cb-6a27-458a-8155-fd368df24eef" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Employer",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SupervisorId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b4e9f30-05e5-49af-b472-3fd878bad75f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3df8c2f-3d9a-44dd-95e6-09afaa28c4d6", "AQAAAAIAAYagAAAAEBXY956jxOOiqV7Cii8RTaMiEyano6rMfk4DO0AatYgNFQlicE3P8euR/yqsorbZQQ==", "8ac14d1e-59a8-4c0f-8967-8a41db021a43" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d6189cb-6a27-458a-8155-fd368df24eef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55d35eeb-4921-4a5e-bc3b-390175e66178", "AQAAAAIAAYagAAAAEKBipOSzZ50WOd3oDK2sl8nvgVWHPOxUSoO79VN6U57ykCpkCSt1zxO+y9cJ4jt+/g==", "3b7634cd-3a42-4494-b77d-d112e686b3b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83703abf-0de1-44ba-b92d-00761bd419ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8fa5168-8879-4078-8b86-a93e2925feae", "AQAAAAIAAYagAAAAEG+hNzk6MVZmAdz2EfUf9V92TOWx3x1J+b28ehZNU31wMkuoHJbq5hA0og0w0ZCjIA==", "d9c374cf-ff6b-4d81-8823-c1dcb5818923" });
        }
    }
}

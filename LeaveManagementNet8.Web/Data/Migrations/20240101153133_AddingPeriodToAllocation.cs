using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementNet8.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingPeriodToAllocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b4e9f30-05e5-49af-b472-3fd878bad75f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f3aa850-5610-4d20-a7db-976e55a11614", "AQAAAAIAAYagAAAAEPAkDZNQVC4MNJ7mJX/INhVFE05WfeBdJPIc8XqitKJeHudiN1tzdoag+yPYWrQaZg==", "4dfd92a7-8907-4469-93d4-0f238d8a3089" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d6189cb-6a27-458a-8155-fd368df24eef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc1d6228-d7c7-4cf4-8d8e-fc011c2f2d34", "AQAAAAIAAYagAAAAECicRqc5JI5UC+A2ZBo2BqC9SFgOUH1fLjVDY95efyDSe8OZtGSCP7psJOaBtNROGQ==", "189915c7-308b-463a-b986-8fc910243c65" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83703abf-0de1-44ba-b92d-00761bd419ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a89a42fa-562f-4678-8422-932967849719", "AQAAAAIAAYagAAAAELqarhJOcNCgI49NRzmwo/AHOR14sm86vRCsQHgQhCLj9EXjBvgqbBOksqGFb6NAlw==", "98b3bcf2-7cb8-4195-b9e1-5392a1ee75a5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b4e9f30-05e5-49af-b472-3fd878bad75f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0bae71f3-e18a-4d32-acb3-90892a6c9e8a", "AQAAAAIAAYagAAAAELBXH34KH74U30FpkV316hJwu5asjXoCWymLPdTobBmy7uyc7m7gTABn97CUDw0LHw==", "956cee8c-d8b9-482c-8540-b49c7742daf7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d6189cb-6a27-458a-8155-fd368df24eef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef39d0f6-9d39-473a-acfb-60d7b84e5949", "AQAAAAIAAYagAAAAEFVIfcWoSKHzrXTJVaRk13XrtkIDS9W5caZNSF1PrdSYv4raEtrse4Y37QBe/B6eyw==", "69d80961-30b6-4a03-9d26-9fc1a9ce726f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83703abf-0de1-44ba-b92d-00761bd419ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0901591-163c-482e-9de0-a3892e50d494", "AQAAAAIAAYagAAAAEHuJir19WUeYk3b5IV/6oOc902QHUttxzkP2lQ/ObAkxHe/Aj7i2R094nEeepCXr/A==", "2d5ae6ed-8213-4856-9c6b-7292a833c8bd" });
        }
    }
}

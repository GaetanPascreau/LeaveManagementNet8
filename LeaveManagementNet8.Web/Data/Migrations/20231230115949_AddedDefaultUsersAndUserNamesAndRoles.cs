using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementNet8.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultUsersAndUserNamesAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c42045b-0c7d-4899-8b85-1ae7c0408f86", null, "User", "USER" },
                    { "49552dc4-be6e-4b84-90a9-18043bfd5fa9", null, "Administrator", "ADMINISTRATOR" },
                    { "ee994451-0e37-44d3-8636-c7f778bcb9f3", null, "Supervisor", "SUPERVISOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2b4e9f30-05e5-49af-b472-3fd878bad75f", 0, "0bae71f3-e18a-4d32-acb3-90892a6c9e8a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", true, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAELBXH34KH74U30FpkV316hJwu5asjXoCWymLPdTobBmy7uyc7m7gTABn97CUDw0LHw==", null, false, "956cee8c-d8b9-482c-8540-b49c7742daf7", null, false, "admin@localhost.com" },
                    { "3d6189cb-6a27-458a-8155-fd368df24eef", 0, "ef39d0f6-9d39-473a-acfb-60d7b84e5949", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "supervisor@localhost.com", true, "System", "Supervisor", false, null, "SUPERVISOR@LOCALHOST.COM", "SUPERVISOR@LOCALHOST.COM", "AQAAAAIAAYagAAAAEFVIfcWoSKHzrXTJVaRk13XrtkIDS9W5caZNSF1PrdSYv4raEtrse4Y37QBe/B6eyw==", null, false, "69d80961-30b6-4a03-9d26-9fc1a9ce726f", null, false, "supervisor@localhost.com" },
                    { "83703abf-0de1-44ba-b92d-00761bd419ef", 0, "f0901591-163c-482e-9de0-a3892e50d494", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", true, "System", "User", false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEHuJir19WUeYk3b5IV/6oOc902QHUttxzkP2lQ/ObAkxHe/Aj7i2R094nEeepCXr/A==", null, false, "2d5ae6ed-8213-4856-9c6b-7292a833c8bd", null, false, "user@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "49552dc4-be6e-4b84-90a9-18043bfd5fa9", "2b4e9f30-05e5-49af-b472-3fd878bad75f" },
                    { "ee994451-0e37-44d3-8636-c7f778bcb9f3", "3d6189cb-6a27-458a-8155-fd368df24eef" },
                    { "2c42045b-0c7d-4899-8b85-1ae7c0408f86", "83703abf-0de1-44ba-b92d-00761bd419ef" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "49552dc4-be6e-4b84-90a9-18043bfd5fa9", "2b4e9f30-05e5-49af-b472-3fd878bad75f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ee994451-0e37-44d3-8636-c7f778bcb9f3", "3d6189cb-6a27-458a-8155-fd368df24eef" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c42045b-0c7d-4899-8b85-1ae7c0408f86", "83703abf-0de1-44ba-b92d-00761bd419ef" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c42045b-0c7d-4899-8b85-1ae7c0408f86");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49552dc4-be6e-4b84-90a9-18043bfd5fa9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee994451-0e37-44d3-8636-c7f778bcb9f3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b4e9f30-05e5-49af-b472-3fd878bad75f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d6189cb-6a27-458a-8155-fd368df24eef");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83703abf-0de1-44ba-b92d-00761bd419ef");
        }
    }
}

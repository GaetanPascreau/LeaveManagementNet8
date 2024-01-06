using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementNet8.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedLeaveRequestTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false),
                    RequestingEmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeId",
                table: "LeaveRequests",
                column: "LeaveTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

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
    }
}

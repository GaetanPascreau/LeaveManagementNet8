using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementNet8.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedRequestedDaysNumberFieldToLeaveRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "RequestedDaysNumber",
                table: "LeaveRequests",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b4e9f30-05e5-49af-b472-3fd878bad75f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c609e452-78df-4b2c-b0df-48f1f7d1c651", "AQAAAAIAAYagAAAAELNm4DIK+m2l0fv252ltaOXkBggOJnhnxhOhdwTXhuv6CTyliD03qHYAY0dHnV+mCQ==", "d351a085-7602-43e5-95be-c5107a805937" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d6189cb-6a27-458a-8155-fd368df24eef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91280f8c-c0a2-4e74-b3df-6ced1df53eba", "AQAAAAIAAYagAAAAEAI1Y5rbehW3FLLneU/x1RiozxP1Pt7neP2qVDC7hWhtQnA/cb1oPHk/9XcojxfcnA==", "23d88338-1b81-4852-b64c-89f46c9622e9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83703abf-0de1-44ba-b92d-00761bd419ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb78bf92-1692-4ddb-b097-c3aeb2d111a7", "AQAAAAIAAYagAAAAEDLoDNuPRpxlJ8JlKGGhFQW34v4KC0QZAfaFaY1ZHnEVFLoGg3bw0Eqjbrds4vouqg==", "5c062f33-d66a-4fca-b06c-6f0f91a77c3d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestedDaysNumber",
                table: "LeaveRequests");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b4e9f30-05e5-49af-b472-3fd878bad75f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "579c219c-ce9e-4b0d-a680-a680cece5bf6", "AQAAAAIAAYagAAAAEKKJk9q87CXb1AKOqZhuMJNfEqeo6x2y3Gw7EJTvOJ9mCFiFvEoJmc+dGlLyaNQpLQ==", "7de28014-d527-4902-a7b5-b17cd937d070" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d6189cb-6a27-458a-8155-fd368df24eef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb995d6b-c905-4d94-ad6e-06966c68e266", "AQAAAAIAAYagAAAAEISpx+tWCUlopnBHGcfF7CNVNMY2758IbDkdyPncO34hO3hBvC65hEp7tO8tVwjGNg==", "0a809388-8b07-4e4c-82e6-34242de986eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83703abf-0de1-44ba-b92d-00761bd419ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69fdd117-a586-44c1-805e-bcd5fc62a370", "AQAAAAIAAYagAAAAEJ5uc7SwEoNFbEzKJCeSuWEhVTppMl3ySdNSknTmmJSRNk0VwPO8IWi03OTVYP028Q==", "0c20e6ce-ae9e-4b5c-8d99-430b33760183" });
        }
    }
}

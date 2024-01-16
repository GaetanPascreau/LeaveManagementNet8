using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementNet8.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedFullNamePropertyToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b4e9f30-05e5-49af-b472-3fd878bad75f",
                columns: new[] { "ConcurrencyStamp", "FullName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "579c219c-ce9e-4b0d-a680-a680cece5bf6", null, "AQAAAAIAAYagAAAAEKKJk9q87CXb1AKOqZhuMJNfEqeo6x2y3Gw7EJTvOJ9mCFiFvEoJmc+dGlLyaNQpLQ==", "7de28014-d527-4902-a7b5-b17cd937d070" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d6189cb-6a27-458a-8155-fd368df24eef",
                columns: new[] { "ConcurrencyStamp", "FullName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb995d6b-c905-4d94-ad6e-06966c68e266", null, "AQAAAAIAAYagAAAAEISpx+tWCUlopnBHGcfF7CNVNMY2758IbDkdyPncO34hO3hBvC65hEp7tO8tVwjGNg==", "0a809388-8b07-4e4c-82e6-34242de986eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83703abf-0de1-44ba-b92d-00761bd419ef",
                columns: new[] { "ConcurrencyStamp", "FullName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69fdd117-a586-44c1-805e-bcd5fc62a370", null, "AQAAAAIAAYagAAAAEJ5uc7SwEoNFbEzKJCeSuWEhVTppMl3ySdNSknTmmJSRNk0VwPO8IWi03OTVYP028Q==", "0c20e6ce-ae9e-4b5c-8d99-430b33760183" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b4e9f30-05e5-49af-b472-3fd878bad75f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6159cc07-a5fb-4757-b201-bce083975922", "AQAAAAIAAYagAAAAEDL24+HMSZFsNj1wTV+1bMkcafM5Uw9Zes6QoVeS4YYbYvIJqV3gIJb9AgjYdjYAlg==", "c1b95d86-55ea-4176-bee8-fee09b762842" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d6189cb-6a27-458a-8155-fd368df24eef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "93cbc128-261f-44f1-81c3-8f2086a2f4b2", "AQAAAAIAAYagAAAAEAvhTCXCYT87M0/5giM5BfDjb2z9l33dzCAxU7umdUtmS+mXTxtiTp74AhFUbMapRg==", "3c2ef962-20fa-42e6-98af-ee1c68a913d5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83703abf-0de1-44ba-b92d-00761bd419ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c057069a-2d03-49a7-babe-abcd265dd0bb", "AQAAAAIAAYagAAAAEHBrE0h7vin9db+BXFC1ifVhTObOTc/beQVE9gSjoWK7j/bOu4o0I4AZCklXFNePVQ==", "fd2f1dce-35fd-4ae9-affd-94ad5be28d2a" });
        }
    }
}

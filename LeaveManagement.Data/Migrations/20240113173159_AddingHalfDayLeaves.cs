using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementNet8.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingHalfDayLeaves : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "DefaultDays",
                table: "LeaveTypes",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "EndTime",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartTime",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<double>(
                name: "NumberOfDays",
                table: "LeaveAllocations",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "LeaveRequests");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "LeaveRequests");

            migrationBuilder.AlterColumn<int>(
                name: "DefaultDays",
                table: "LeaveTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfDays",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b4e9f30-05e5-49af-b472-3fd878bad75f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68722269-9316-48ae-a928-0ff529938a69", "AQAAAAIAAYagAAAAEIZ27V+aDCOYjHRLS+S/IQNY+DtESXliOulp2AajIgDYKsBDmjgx4pkszpVnEkNlUg==", "c3f2d3aa-63f9-4a26-a6d4-226d7ee7add9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d6189cb-6a27-458a-8155-fd368df24eef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a04c4996-f51c-4ca7-bedc-5a8d43d5ed9d", "AQAAAAIAAYagAAAAEM0e+dvcZGw8VdJv9Mamrd1/bz9ij7aDsTIqF6C0wjN/J+oYUhotHZhEimfPpcJavg==", "dcfba323-d526-47c1-9484-fd9e2c84563e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83703abf-0de1-44ba-b92d-00761bd419ef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ea6b00b-c271-4152-b010-d16fb6860a4a", "AQAAAAIAAYagAAAAENVWA/hK8wxxFgj+t7d47BsCRwY9vLNPhGcac+Si5WUaxIZlH+nBhYlHFOc8xuX7jQ==", "d89afc61-3cde-4b74-b983-1f2dd547c72e" });
        }
    }
}

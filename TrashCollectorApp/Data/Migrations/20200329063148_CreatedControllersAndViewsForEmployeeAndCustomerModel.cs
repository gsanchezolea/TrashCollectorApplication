using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorApp.Data.Migrations
{
    public partial class CreatedControllersAndViewsForEmployeeAndCustomerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e740035-a0d7-4cb1-beb9-1cd4ca833af5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16059c11-8acc-41ba-883c-bd4f54255a13");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0e1d3852-5870-4584-86e9-e19f1c60e514", "2fe4423c-5e6b-47ae-b343-46956a04e6b2", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5e2f294a-7a5d-4d04-b3c6-7272b383ce70", "12799e73-79b5-4cdf-bf7c-a35fd2213303", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e1d3852-5870-4584-86e9-e19f1c60e514");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e2f294a-7a5d-4d04-b3c6-7272b383ce70");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0e740035-a0d7-4cb1-beb9-1cd4ca833af5", "472dd2c6-277e-44b7-bf8c-dedb3875c55b", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "16059c11-8acc-41ba-883c-bd4f54255a13", "7e5df926-17e0-4f3c-8764-3adb0aebd47c", "Employee", "EMPLOYEE" });
        }
    }
}

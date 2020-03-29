using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorApp.Data.Migrations
{
    public partial class RemovedMaxLengthDataAnnotationFromZipCodePropertyInAddressModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "11b9189b-e2a1-4a3f-b2e5-022a4a30068f", "2aa19346-197c-40a5-acb2-e1927f34998d", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "18026641-ef18-400e-b457-18fdaec8dcf2", "0ab86b0a-eedf-4daa-b69a-f6e95a9666ec", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11b9189b-e2a1-4a3f-b2e5-022a4a30068f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18026641-ef18-400e-b457-18fdaec8dcf2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0e1d3852-5870-4584-86e9-e19f1c60e514", "2fe4423c-5e6b-47ae-b343-46956a04e6b2", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5e2f294a-7a5d-4d04-b3c6-7272b383ce70", "12799e73-79b5-4cdf-bf7c-a35fd2213303", "Employee", "EMPLOYEE" });
        }
    }
}

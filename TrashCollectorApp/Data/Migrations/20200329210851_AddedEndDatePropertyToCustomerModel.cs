using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorApp.Data.Migrations
{
    public partial class AddedEndDatePropertyToCustomerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11b9189b-e2a1-4a3f-b2e5-022a4a30068f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18026641-ef18-400e-b457-18fdaec8dcf2");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "05d5ad1d-5680-4710-9158-a659c00d5505", "1e7e06be-d665-4748-b980-e5c07ba210d9", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "baee42aa-50fd-4c0c-beeb-b09f8e2cc7b9", "25ac4e3e-a224-4a94-b7c6-e8886d9f63f2", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05d5ad1d-5680-4710-9158-a659c00d5505");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "baee42aa-50fd-4c0c-beeb-b09f8e2cc7b9");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "11b9189b-e2a1-4a3f-b2e5-022a4a30068f", "2aa19346-197c-40a5-acb2-e1927f34998d", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "18026641-ef18-400e-b457-18fdaec8dcf2", "0ab86b0a-eedf-4daa-b69a-f6e95a9666ec", "Employee", "EMPLOYEE" });
        }
    }
}

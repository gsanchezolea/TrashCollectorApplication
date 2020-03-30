using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorApp.Data.Migrations
{
    public partial class RemovedPickUpDayPropertyFromCustomerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71de59b7-cc30-4351-b596-f10baf8174df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac4a042b-d82e-487c-bc3b-d1ce63d73255");

            migrationBuilder.DropColumn(
                name: "PickUpDay",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "40c62f94-5724-4904-9405-526cc388553c", "6deab0db-6e57-4543-ba5f-fdb85dba8a57", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7dc198c6-1970-4c85-aa98-f889be91237e", "e9aeaa2a-7c89-494a-9ae9-b8afcb466d23", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40c62f94-5724-4904-9405-526cc388553c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7dc198c6-1970-4c85-aa98-f889be91237e");

            migrationBuilder.AddColumn<DateTime>(
                name: "PickUpDay",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "71de59b7-cc30-4351-b596-f10baf8174df", "13baf23c-bb05-482e-94e5-1985b6a93c87", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ac4a042b-d82e-487c-bc3b-d1ce63d73255", "1f3fa635-0eb7-4bf7-bd17-d2893cd3193f", "Employee", "EMPLOYEE" });
        }
    }
}

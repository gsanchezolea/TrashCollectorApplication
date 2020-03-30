using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorApp.Data.Migrations
{
    public partial class AddedDisplayNameToPickUpDateProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62b6f999-76fb-40cc-935a-a335d9ec472d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a108169c-6a03-423a-8c30-0e40e7bb413a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0821f5e7-9ebf-44f9-b582-31d15b020ffb", "44f5847e-e80f-4d3f-b178-04b3bcc358b4", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e08b30a0-c4a4-4cb6-9fd9-674b354b1a64", "ff6e8eed-c3c4-4888-8bf7-7661cbd66ed2", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0821f5e7-9ebf-44f9-b582-31d15b020ffb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e08b30a0-c4a4-4cb6-9fd9-674b354b1a64");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "62b6f999-76fb-40cc-935a-a335d9ec472d", "69accc0e-4827-43d9-9918-4dbde8daeafe", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a108169c-6a03-423a-8c30-0e40e7bb413a", "066da0d5-0862-42be-8d19-19970351df1a", "Employee", "EMPLOYEE" });
        }
    }
}

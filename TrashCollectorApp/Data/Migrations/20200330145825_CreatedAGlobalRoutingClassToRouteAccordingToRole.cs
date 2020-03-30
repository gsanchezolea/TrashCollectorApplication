using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorApp.Data.Migrations
{
    public partial class CreatedAGlobalRoutingClassToRouteAccordingToRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3429e07f-da76-4f0b-897d-98a4e7437209");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9e6a651-7199-4900-9463-63cc35c12511");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "71de59b7-cc30-4351-b596-f10baf8174df", "13baf23c-bb05-482e-94e5-1985b6a93c87", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ac4a042b-d82e-487c-bc3b-d1ce63d73255", "1f3fa635-0eb7-4bf7-bd17-d2893cd3193f", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71de59b7-cc30-4351-b596-f10baf8174df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac4a042b-d82e-487c-bc3b-d1ce63d73255");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3429e07f-da76-4f0b-897d-98a4e7437209", "ff67848c-d370-403a-a3e2-30edc4f84f25", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9e6a651-7199-4900-9463-63cc35c12511", "ff63beeb-709a-4a9f-956b-cb9fe37af71e", "Employee", "EMPLOYEE" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorApp.Data.Migrations
{
    public partial class RemovedFKPickUpFromCustomerModelAddedFkCustomerToPickUpModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_PickUps_PickUpId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_PickUpId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0821f5e7-9ebf-44f9-b582-31d15b020ffb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e08b30a0-c4a4-4cb6-9fd9-674b354b1a64");

            migrationBuilder.DropColumn(
                name: "PickUpId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "PickUps",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3429e07f-da76-4f0b-897d-98a4e7437209", "ff67848c-d370-403a-a3e2-30edc4f84f25", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9e6a651-7199-4900-9463-63cc35c12511", "ff63beeb-709a-4a9f-956b-cb9fe37af71e", "Employee", "EMPLOYEE" });

            migrationBuilder.CreateIndex(
                name: "IX_PickUps_CustomerId",
                table: "PickUps",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PickUps_Customers_CustomerId",
                table: "PickUps",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PickUps_Customers_CustomerId",
                table: "PickUps");

            migrationBuilder.DropIndex(
                name: "IX_PickUps_CustomerId",
                table: "PickUps");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3429e07f-da76-4f0b-897d-98a4e7437209");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9e6a651-7199-4900-9463-63cc35c12511");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "PickUps");

            migrationBuilder.AddColumn<int>(
                name: "PickUpId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0821f5e7-9ebf-44f9-b582-31d15b020ffb", "44f5847e-e80f-4d3f-b178-04b3bcc358b4", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e08b30a0-c4a4-4cb6-9fd9-674b354b1a64", "ff6e8eed-c3c4-4888-8bf7-7661cbd66ed2", "Employee", "EMPLOYEE" });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PickUpId",
                table: "Customers",
                column: "PickUpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_PickUps_PickUpId",
                table: "Customers",
                column: "PickUpId",
                principalTable: "PickUps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

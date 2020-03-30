using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorApp.Data.Migrations
{
    public partial class RevertedLastMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_PickUps_PickUpId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8570f830-7b8d-471b-a15f-68b3d2357dc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbbd9c09-f80f-451b-8260-a71863525216");

            migrationBuilder.AlterColumn<int>(
                name: "PickUpId",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "62b6f999-76fb-40cc-935a-a335d9ec472d", "69accc0e-4827-43d9-9918-4dbde8daeafe", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a108169c-6a03-423a-8c30-0e40e7bb413a", "066da0d5-0862-42be-8d19-19970351df1a", "Employee", "EMPLOYEE" });

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_PickUps_PickUpId",
                table: "Customers",
                column: "PickUpId",
                principalTable: "PickUps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_PickUps_PickUpId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62b6f999-76fb-40cc-935a-a335d9ec472d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a108169c-6a03-423a-8c30-0e40e7bb413a");

            migrationBuilder.AlterColumn<int>(
                name: "PickUpId",
                table: "Customers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8570f830-7b8d-471b-a15f-68b3d2357dc2", "88280197-aeb1-4b95-a861-5e9724f96340", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bbbd9c09-f80f-451b-8260-a71863525216", "0d887001-7430-45e8-ba00-729f73d8fa7e", "Employee", "EMPLOYEE" });

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_PickUps_PickUpId",
                table: "Customers",
                column: "PickUpId",
                principalTable: "PickUps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

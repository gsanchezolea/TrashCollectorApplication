using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorApp.Data.Migrations
{
    public partial class MadePickUpForeignKeyNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_PickUps_PickUpId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7dd172da-af98-4d26-8a90-933eb1de150f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8857ef44-cc41-4dae-9e60-710ef4e02dea");

            migrationBuilder.AlterColumn<int>(
                name: "PickUpId",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7dd172da-af98-4d26-8a90-933eb1de150f", "083bad1f-b88f-4caa-8d4f-0e5a5f70e923", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8857ef44-cc41-4dae-9e60-710ef4e02dea", "b5ab1d52-d53f-46df-bd56-240c0644fd0d", "Employee", "EMPLOYEE" });

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

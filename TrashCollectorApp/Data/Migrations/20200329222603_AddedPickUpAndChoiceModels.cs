using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorApp.Data.Migrations
{
    public partial class AddedPickUpAndChoiceModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05d5ad1d-5680-4710-9158-a659c00d5505");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "baee42aa-50fd-4c0c-beeb-b09f8e2cc7b9");

            migrationBuilder.AddColumn<int>(
                name: "PickUpId",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Choices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PickUps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChoiceId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Confirmed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickUps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PickUps_Choices_ChoiceId",
                        column: x => x.ChoiceId,
                        principalTable: "Choices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7dd172da-af98-4d26-8a90-933eb1de150f", "083bad1f-b88f-4caa-8d4f-0e5a5f70e923", "Customer", "CUSTOMER" },
                    { "8857ef44-cc41-4dae-9e60-710ef4e02dea", "b5ab1d52-d53f-46df-bd56-240c0644fd0d", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Scheduled" },
                    { 2, "One-Time" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PickUpId",
                table: "Customers",
                column: "PickUpId");

            migrationBuilder.CreateIndex(
                name: "IX_PickUps_ChoiceId",
                table: "PickUps",
                column: "ChoiceId");

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

            migrationBuilder.DropTable(
                name: "PickUps");

            migrationBuilder.DropTable(
                name: "Choices");

            migrationBuilder.DropIndex(
                name: "IX_Customers_PickUpId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7dd172da-af98-4d26-8a90-933eb1de150f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8857ef44-cc41-4dae-9e60-710ef4e02dea");

            migrationBuilder.DropColumn(
                name: "PickUpId",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "05d5ad1d-5680-4710-9158-a659c00d5505", "1e7e06be-d665-4748-b980-e5c07ba210d9", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "baee42aa-50fd-4c0c-beeb-b09f8e2cc7b9", "25ac4e3e-a224-4a94-b7c6-e8886d9f63f2", "Employee", "EMPLOYEE" });
        }
    }
}

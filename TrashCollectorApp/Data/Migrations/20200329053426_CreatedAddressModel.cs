using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorApp.Data.Migrations
{
    public partial class CreatedAddressModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b49d55f8-ae0d-4577-82aa-78cb4668221a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e16f463f-c71c-4f5a-8bcd-06a7f4c94fe5");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetAddress = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    ZipCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3890bc1e-9bed-498b-a859-3e0f2bd99c66", "8b21963e-0a43-4a61-bf11-42c7e54ddc8b", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "203bf82f-7631-439b-8556-277e3a672f1c", "df90d0fc-0ecf-407d-b8ee-a42523635af1", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "203bf82f-7631-439b-8556-277e3a672f1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3890bc1e-9bed-498b-a859-3e0f2bd99c66");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e16f463f-c71c-4f5a-8bcd-06a7f4c94fe5", "de539116-9456-41b9-94b6-426a4122fb87", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b49d55f8-ae0d-4577-82aa-78cb4668221a", "1c860d90-ae5f-49fa-804c-7f9d209b435a", "Employee", "EMPLOYEE" });
        }
    }
}

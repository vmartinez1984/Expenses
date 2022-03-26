using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Expenses.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MontsWithoutInterest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExpensesTotal = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MontsWithoutInterest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MontsWithoutInterestDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ExpenseNumber = table.Column<int>(type: "int", nullable: false),
                    MontsWithoutInterestId = table.Column<int>(type: "int", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MontsWithoutInterestDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MontsWithoutInterestDetails_MontsWithoutInterest_MontsWithoutInterestId",
                        column: x => x.MontsWithoutInterestId,
                        principalTable: "MontsWithoutInterest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DepositPlan",
                columns: new[] { "Id", "Amount", "CategoryId1", "DateRegister", "Goal", "IsActive", "Name", "SubcategoryId" },
                values: new object[,]
                {
                    { 1, 200, null, new DateTime(2022, 3, 25, 12, 15, 44, 10, DateTimeKind.Local).AddTicks(5813), 2000, true, "Sabatico", 4 },
                    { 2, 500, null, new DateTime(2022, 3, 25, 12, 15, 44, 10, DateTimeKind.Local).AddTicks(6191), 2000, true, "Afore", 5 },
                    { 3, 350, null, new DateTime(2022, 3, 25, 12, 15, 44, 10, DateTimeKind.Local).AddTicks(6197), 2000, true, "Seminario", 6 },
                    { 4, 100, null, new DateTime(2022, 3, 25, 12, 15, 44, 10, DateTimeKind.Local).AddTicks(6202), 2000, true, "Camioneta", 7 },
                    { 5, 100, null, new DateTime(2022, 3, 25, 12, 15, 44, 10, DateTimeKind.Local).AddTicks(6207), 2000, true, "Libros Tec", 8 },
                    { 6, 100, null, new DateTime(2022, 3, 25, 12, 15, 44, 10, DateTimeKind.Local).AddTicks(6212), 2000, true, "Ropa", 9 },
                    { 7, 400, null, new DateTime(2022, 3, 25, 12, 15, 44, 10, DateTimeKind.Local).AddTicks(6217), 2000, true, "Tlax", 10 },
                    { 8, 100, null, new DateTime(2022, 3, 25, 12, 15, 44, 10, DateTimeKind.Local).AddTicks(6222), 2000, true, "Gastos medicos", 11 },
                    { 9, 100, null, new DateTime(2022, 3, 25, 12, 15, 44, 10, DateTimeKind.Local).AddTicks(6226), 2000, true, "Ahorro N", 12 }
                });

            migrationBuilder.UpdateData(
                table: "Subcategory",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Gastos Medicos $100");

            migrationBuilder.CreateIndex(
                name: "IX_MontsWithoutInterestDetails_MontsWithoutInterestId",
                table: "MontsWithoutInterestDetails",
                column: "MontsWithoutInterestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MontsWithoutInterestDetails");

            migrationBuilder.DropTable(
                name: "MontsWithoutInterest");

            migrationBuilder.DeleteData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Subcategory",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Gastos Medicos $400");
        }
    }
}

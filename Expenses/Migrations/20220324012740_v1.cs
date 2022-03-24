using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Expenses.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Period",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateStop = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Period", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subcategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subcategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entry_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepositPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Goal = table.Column<int>(type: "int", nullable: false),
                    CategoryId1 = table.Column<int>(type: "int", nullable: true),
                    SubcategoryId = table.Column<int>(type: "int", nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepositPlan_Category_CategoryId1",
                        column: x => x.CategoryId1,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepositPlan_Subcategory_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "Subcategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CategoryId1 = table.Column<int>(type: "int", nullable: true),
                    SubcategoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expense_Category_CategoryId1",
                        column: x => x.CategoryId1,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expense_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expense_Subcategory_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "Subcategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deposit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CategoryId1 = table.Column<int>(type: "int", nullable: true),
                    SubcategoryId = table.Column<int>(type: "int", nullable: false),
                    DepositPlanId = table.Column<int>(type: "int", nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deposit_Category_CategoryId1",
                        column: x => x.CategoryId1,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deposit_DepositPlan_DepositPlanId",
                        column: x => x.DepositPlanId,
                        principalTable: "DepositPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deposit_Subcategory_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "Subcategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "Pagos" },
                    { 2, true, "Ahorros" },
                    { 3, true, "Alimentación" },
                    { 4, true, "Gatos" },
                    { 5, true, "Servicios" },
                    { 6, true, "Educación" }
                });

            migrationBuilder.InsertData(
                table: "Subcategory",
                columns: new[] { "Id", "CategoryId", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, 1, true, "TDC" },
                    { 17, 5, true, "Internet" },
                    { 16, 4, true, "Gatos" },
                    { 15, 3, true, "Golosinas" },
                    { 14, 3, true, "Por App" },
                    { 13, 3, true, "Alimentación corriente" },
                    { 12, 2, true, "Ahorron $200" },
                    { 11, 2, true, "Gastos Medicos $400" },
                    { 18, 5, true, "Agua" },
                    { 10, 2, true, "Tlaxc $400" },
                    { 8, 2, true, "Libros Tec $100" },
                    { 7, 2, true, "Camioneta $100" },
                    { 6, 2, true, "Plan Seminario $350" },
                    { 5, 2, true, "Plan Afore $500" },
                    { 4, 2, true, "Plan sabatico $200" },
                    { 3, 1, true, "Mili $400" },
                    { 2, 1, true, "Doña $1200" },
                    { 9, 2, true, "Ropa $100" },
                    { 19, 5, true, "Luz" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deposit_CategoryId1",
                table: "Deposit",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Deposit_DepositPlanId",
                table: "Deposit",
                column: "DepositPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Deposit_SubcategoryId",
                table: "Deposit",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositPlan_CategoryId1",
                table: "DepositPlan",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_DepositPlan_SubcategoryId",
                table: "DepositPlan",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Entry_PeriodId",
                table: "Entry",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_CategoryId1",
                table: "Expense",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_PeriodId",
                table: "Expense",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_SubcategoryId",
                table: "Expense",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategory_CategoryId",
                table: "Subcategory",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deposit");

            migrationBuilder.DropTable(
                name: "Entry");

            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "DepositPlan");

            migrationBuilder.DropTable(
                name: "Period");

            migrationBuilder.DropTable(
                name: "Subcategory");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}

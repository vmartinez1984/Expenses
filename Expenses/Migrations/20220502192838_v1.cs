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
                name: "ExpenseTdc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseTdc", x => x.Id);
                });

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
                name: "TermAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Term = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subcategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    IsBudget = table.Column<bool>(type: "bit", nullable: false),
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
                    SubcategoryId = table.Column<int>(type: "int", nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositPlan", x => x.Id);
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
                    BudgetAmount = table.Column<int>(type: "int", nullable: true),
                    SubcategoryId = table.Column<int>(type: "int", nullable: false),
                    DepositPlanId = table.Column<int>(type: "int", nullable: true),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expense_DepositPlan_DepositPlanId",
                        column: x => x.DepositPlanId,
                        principalTable: "DepositPlan",
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
                columns: new[] { "Id", "Amount", "CategoryId", "IsActive", "IsBudget", "Name" },
                values: new object[,]
                {
                    { 1, null, 1, true, false, "TDC" },
                    { 17, null, 5, true, false, "Internet" },
                    { 16, null, 4, true, false, "Gatos" },
                    { 15, null, 3, true, false, "Golosinas" },
                    { 14, null, 3, true, false, "Por App" },
                    { 13, null, 3, true, false, "Alimentación corriente" },
                    { 12, null, 2, true, false, "Ahorron $200" },
                    { 11, null, 2, true, false, "Gastos Medicos $100" },
                    { 18, null, 5, true, false, "Agua" },
                    { 10, null, 2, true, false, "Tlaxc $400" },
                    { 8, null, 2, true, false, "Libros Tec $100" },
                    { 7, null, 2, true, false, "Camioneta $100" },
                    { 6, null, 2, true, false, "Plan Seminario $350" },
                    { 5, null, 2, true, false, "Plan Afore $500" },
                    { 4, null, 2, true, false, "Plan sabatico $200" },
                    { 3, null, 1, true, false, "Mili $400" },
                    { 2, null, 1, true, false, "Doña $1200" },
                    { 9, null, 2, true, false, "Ropa $100" },
                    { 19, null, 5, true, false, "Luz" }
                });

            migrationBuilder.InsertData(
                table: "DepositPlan",
                columns: new[] { "Id", "Amount", "DateRegister", "Goal", "IsActive", "Name", "SubcategoryId" },
                values: new object[,]
                {
                    { 1, 200, new DateTime(2022, 5, 2, 14, 28, 37, 643, DateTimeKind.Local).AddTicks(8308), 2000, true, "Sabatico", 4 },
                    { 2, 500, new DateTime(2022, 5, 2, 14, 28, 37, 643, DateTimeKind.Local).AddTicks(8846), 2000, true, "Afore", 5 },
                    { 3, 350, new DateTime(2022, 5, 2, 14, 28, 37, 643, DateTimeKind.Local).AddTicks(8851), 2000, true, "Seminario", 6 },
                    { 4, 100, new DateTime(2022, 5, 2, 14, 28, 37, 643, DateTimeKind.Local).AddTicks(8855), 2000, true, "Camioneta", 7 },
                    { 5, 100, new DateTime(2022, 5, 2, 14, 28, 37, 643, DateTimeKind.Local).AddTicks(8859), 2000, true, "Libros Tec", 8 },
                    { 6, 100, new DateTime(2022, 5, 2, 14, 28, 37, 643, DateTimeKind.Local).AddTicks(8863), 2000, true, "Ropa", 9 },
                    { 7, 400, new DateTime(2022, 5, 2, 14, 28, 37, 643, DateTimeKind.Local).AddTicks(8867), 2000, true, "Tlax", 10 },
                    { 8, 100, new DateTime(2022, 5, 2, 14, 28, 37, 643, DateTimeKind.Local).AddTicks(8871), 2000, true, "Gastos medicos", 11 },
                    { 9, 100, new DateTime(2022, 5, 2, 14, 28, 37, 643, DateTimeKind.Local).AddTicks(8875), 2000, true, "Ahorro N", 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepositPlan_SubcategoryId",
                table: "DepositPlan",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Entry_PeriodId",
                table: "Entry",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_DepositPlanId",
                table: "Expense",
                column: "DepositPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_PeriodId",
                table: "Expense",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_SubcategoryId",
                table: "Expense",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MontsWithoutInterestDetails_MontsWithoutInterestId",
                table: "MontsWithoutInterestDetails",
                column: "MontsWithoutInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategory_CategoryId",
                table: "Subcategory",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entry");

            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "ExpenseTdc");

            migrationBuilder.DropTable(
                name: "MontsWithoutInterestDetails");

            migrationBuilder.DropTable(
                name: "TermAccount");

            migrationBuilder.DropTable(
                name: "DepositPlan");

            migrationBuilder.DropTable(
                name: "Period");

            migrationBuilder.DropTable(
                name: "MontsWithoutInterest");

            migrationBuilder.DropTable(
                name: "Subcategory");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}

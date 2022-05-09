using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Expenses.Migrations
{
    public partial class MesesSinIntereses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MonthsWithoutInterest",
                table: "ExpenseTdc",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[] { 7, true, "Becas" });

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegister",
                value: new DateTime(2022, 5, 9, 9, 32, 26, 825, DateTimeKind.Local).AddTicks(6695));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegister",
                value: new DateTime(2022, 5, 9, 9, 32, 26, 825, DateTimeKind.Local).AddTicks(7058));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegister",
                value: new DateTime(2022, 5, 9, 9, 32, 26, 825, DateTimeKind.Local).AddTicks(7063));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateRegister",
                value: new DateTime(2022, 5, 9, 9, 32, 26, 825, DateTimeKind.Local).AddTicks(7067));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateRegister",
                value: new DateTime(2022, 5, 9, 9, 32, 26, 825, DateTimeKind.Local).AddTicks(7070));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateRegister",
                value: new DateTime(2022, 5, 9, 9, 32, 26, 825, DateTimeKind.Local).AddTicks(7074));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateRegister",
                value: new DateTime(2022, 5, 9, 9, 32, 26, 825, DateTimeKind.Local).AddTicks(7081));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateRegister",
                value: new DateTime(2022, 5, 9, 9, 32, 26, 825, DateTimeKind.Local).AddTicks(7085));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateRegister",
                value: new DateTime(2022, 5, 9, 9, 32, 26, 825, DateTimeKind.Local).AddTicks(7089));

            migrationBuilder.InsertData(
                table: "DepositPlan",
                columns: new[] { "Id", "Amount", "DateRegister", "Goal", "IsActive", "Name", "SubcategoryId" },
                values: new object[] { 10, 100, new DateTime(2022, 5, 9, 9, 32, 26, 825, DateTimeKind.Local).AddTicks(7094), 2000, true, "Vacaciones", 12 });

            migrationBuilder.InsertData(
                table: "Period",
                columns: new[] { "Id", "DateStart", "DateStop", "IsActive", "Name" },
                values: new object[] { 1, new DateTime(2022, 5, 9, 9, 32, 26, 825, DateTimeKind.Local).AddTicks(8376), new DateTime(2022, 5, 9, 9, 32, 26, 825, DateTimeKind.Local).AddTicks(8653), false, "Ahorros" });

            migrationBuilder.UpdateData(
                table: "Subcategory",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Amount", "IsBudget", "Name" },
                values: new object[] { 600, true, "Semana 1" });

            migrationBuilder.UpdateData(
                table: "Subcategory",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Amount", "IsBudget", "Name" },
                values: new object[] { 600, true, "Semana 2" });

            migrationBuilder.UpdateData(
                table: "Subcategory",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Amount", "IsBudget", "Name" },
                values: new object[] { 200, true, "Plan sabatico" });

            migrationBuilder.UpdateData(
                table: "Subcategory",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Amount", "IsBudget", "Name" },
                values: new object[] { 500, true, "Plan Afore" });

            migrationBuilder.UpdateData(
                table: "Subcategory",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Amount", "IsBudget", "Name" },
                values: new object[] { 750, true, "Plan Seminario" });

            migrationBuilder.UpdateData(
                table: "Subcategory",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Amount", "IsBudget", "Name" },
                values: new object[] { 90, true, "Internet Tlax" });

            migrationBuilder.UpdateData(
                table: "Subcategory",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Amount", "IsBudget", "Name" },
                values: new object[] { 175, true, "Internet CDMX" });

            migrationBuilder.UpdateData(
                table: "Subcategory",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Amount", "IsBudget", "Name" },
                values: new object[] { 75, true, "Agua CDMX" });

            migrationBuilder.InsertData(
                table: "Subcategory",
                columns: new[] { "Id", "Amount", "CategoryId", "IsActive", "IsBudget", "Name" },
                values: new object[,]
                {
                    { 22, 100, 2, true, true, "Vacaciones" },
                    { 20, 75, 5, true, true, "Luz Tlax" },
                    { 24, 400, 5, true, true, "Mili" },
                    { 21, 150, 5, true, true, "Luz CDMX" },
                    { 23, 1200, 5, true, true, "Doña" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Period",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subcategory",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Subcategory",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Subcategory",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Subcategory",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Subcategory",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DropColumn(
                name: "MonthsWithoutInterest",
                table: "ExpenseTdc");

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegister",
                value: new DateTime(2022, 5, 2, 14, 28, 37, 643, DateTimeKind.Local).AddTicks(8308));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegister",
                value: new DateTime(2022, 5, 2, 14, 28, 37, 643, DateTimeKind.Local).AddTicks(8846));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegister",
                value: new DateTime(2022, 5, 2, 14, 28, 37, 643, DateTimeKind.Local).AddTicks(8851));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateRegister",
                value: new DateTime(2022, 5, 2, 14, 28, 37, 643, DateTimeKind.Local).AddTicks(8855));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateRegister",
                value: new DateTime(2022, 5, 2, 14, 28, 37, 643, DateTimeKind.Local).AddTicks(8859));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateRegister",
                value: new DateTime(2022, 5, 2, 14, 28, 37, 643, DateTimeKind.Local).AddTicks(8863));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateRegister",
                value: new DateTime(2022, 5, 2, 14, 28, 37, 643, DateTimeKind.Local).AddTicks(8867));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateRegister",
                value: new DateTime(2022, 5, 2, 14, 28, 37, 643, DateTimeKind.Local).AddTicks(8871));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateRegister",
                value: new DateTime(2022, 5, 2, 14, 28, 37, 643, DateTimeKind.Local).AddTicks(8875));

            migrationBuilder.UpdateData(
                table: "Subcategory",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Amount", "IsBudget", "Name" },
                values: new object[] { null, false, "Doña $1200" });

            migrationBuilder.UpdateData(
                table: "Subcategory",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Amount", "IsBudget", "Name" },
                values: new object[] { null, false, "Mili $400" });

            migrationBuilder.UpdateData(
                table: "Subcategory",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Amount", "IsBudget", "Name" },
                values: new object[] { null, false, "Plan sabatico $200" });

            migrationBuilder.UpdateData(
                table: "Subcategory",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Amount", "IsBudget", "Name" },
                values: new object[] { null, false, "Plan Afore $500" });

            migrationBuilder.UpdateData(
                table: "Subcategory",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Amount", "IsBudget", "Name" },
                values: new object[] { null, false, "Plan Seminario $350" });

            migrationBuilder.UpdateData(
                table: "Subcategory",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Amount", "IsBudget", "Name" },
                values: new object[] { null, false, "Internet" });

            migrationBuilder.UpdateData(
                table: "Subcategory",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Amount", "IsBudget", "Name" },
                values: new object[] { null, false, "Agua" });

            migrationBuilder.UpdateData(
                table: "Subcategory",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Amount", "IsBudget", "Name" },
                values: new object[] { null, false, "Luz" });
        }
    }
}

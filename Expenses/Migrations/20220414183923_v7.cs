using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Expenses.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Subcategory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBudget",
                table: "Subcategory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "BudgetAmount",
                table: "Expense",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegister",
                value: new DateTime(2022, 4, 14, 13, 39, 22, 521, DateTimeKind.Local).AddTicks(3834));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegister",
                value: new DateTime(2022, 4, 14, 13, 39, 22, 521, DateTimeKind.Local).AddTicks(4180));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegister",
                value: new DateTime(2022, 4, 14, 13, 39, 22, 521, DateTimeKind.Local).AddTicks(4187));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateRegister",
                value: new DateTime(2022, 4, 14, 13, 39, 22, 521, DateTimeKind.Local).AddTicks(4192));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateRegister",
                value: new DateTime(2022, 4, 14, 13, 39, 22, 521, DateTimeKind.Local).AddTicks(4198));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateRegister",
                value: new DateTime(2022, 4, 14, 13, 39, 22, 521, DateTimeKind.Local).AddTicks(4204));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateRegister",
                value: new DateTime(2022, 4, 14, 13, 39, 22, 521, DateTimeKind.Local).AddTicks(4209));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateRegister",
                value: new DateTime(2022, 4, 14, 13, 39, 22, 521, DateTimeKind.Local).AddTicks(4214));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateRegister",
                value: new DateTime(2022, 4, 14, 13, 39, 22, 521, DateTimeKind.Local).AddTicks(4219));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Subcategory");

            migrationBuilder.DropColumn(
                name: "IsBudget",
                table: "Subcategory");

            migrationBuilder.DropColumn(
                name: "BudgetAmount",
                table: "Expense");

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegister",
                value: new DateTime(2022, 4, 13, 14, 11, 7, 270, DateTimeKind.Local).AddTicks(4921));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegister",
                value: new DateTime(2022, 4, 13, 14, 11, 7, 270, DateTimeKind.Local).AddTicks(5254));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegister",
                value: new DateTime(2022, 4, 13, 14, 11, 7, 270, DateTimeKind.Local).AddTicks(5261));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateRegister",
                value: new DateTime(2022, 4, 13, 14, 11, 7, 270, DateTimeKind.Local).AddTicks(5266));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateRegister",
                value: new DateTime(2022, 4, 13, 14, 11, 7, 270, DateTimeKind.Local).AddTicks(5271));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateRegister",
                value: new DateTime(2022, 4, 13, 14, 11, 7, 270, DateTimeKind.Local).AddTicks(5276));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateRegister",
                value: new DateTime(2022, 4, 13, 14, 11, 7, 270, DateTimeKind.Local).AddTicks(5281));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateRegister",
                value: new DateTime(2022, 4, 13, 14, 11, 7, 270, DateTimeKind.Local).AddTicks(5286));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateRegister",
                value: new DateTime(2022, 4, 13, 14, 11, 7, 270, DateTimeKind.Local).AddTicks(5291));
        }
    }
}

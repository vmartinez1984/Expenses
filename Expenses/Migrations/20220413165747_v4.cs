using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Expenses.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegister",
                value: new DateTime(2022, 4, 13, 11, 57, 46, 803, DateTimeKind.Local).AddTicks(7051));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegister",
                value: new DateTime(2022, 4, 13, 11, 57, 46, 803, DateTimeKind.Local).AddTicks(7379));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegister",
                value: new DateTime(2022, 4, 13, 11, 57, 46, 803, DateTimeKind.Local).AddTicks(7385));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateRegister",
                value: new DateTime(2022, 4, 13, 11, 57, 46, 803, DateTimeKind.Local).AddTicks(7390));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateRegister",
                value: new DateTime(2022, 4, 13, 11, 57, 46, 803, DateTimeKind.Local).AddTicks(7395));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateRegister",
                value: new DateTime(2022, 4, 13, 11, 57, 46, 803, DateTimeKind.Local).AddTicks(7400));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateRegister",
                value: new DateTime(2022, 4, 13, 11, 57, 46, 803, DateTimeKind.Local).AddTicks(7405));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateRegister",
                value: new DateTime(2022, 4, 13, 11, 57, 46, 803, DateTimeKind.Local).AddTicks(7409));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateRegister",
                value: new DateTime(2022, 4, 13, 11, 57, 46, 803, DateTimeKind.Local).AddTicks(7414));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegister",
                value: new DateTime(2022, 3, 25, 12, 15, 44, 10, DateTimeKind.Local).AddTicks(5813));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegister",
                value: new DateTime(2022, 3, 25, 12, 15, 44, 10, DateTimeKind.Local).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegister",
                value: new DateTime(2022, 3, 25, 12, 15, 44, 10, DateTimeKind.Local).AddTicks(6197));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateRegister",
                value: new DateTime(2022, 3, 25, 12, 15, 44, 10, DateTimeKind.Local).AddTicks(6202));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateRegister",
                value: new DateTime(2022, 3, 25, 12, 15, 44, 10, DateTimeKind.Local).AddTicks(6207));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateRegister",
                value: new DateTime(2022, 3, 25, 12, 15, 44, 10, DateTimeKind.Local).AddTicks(6212));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateRegister",
                value: new DateTime(2022, 3, 25, 12, 15, 44, 10, DateTimeKind.Local).AddTicks(6217));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateRegister",
                value: new DateTime(2022, 3, 25, 12, 15, 44, 10, DateTimeKind.Local).AddTicks(6222));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateRegister",
                value: new DateTime(2022, 3, 25, 12, 15, 44, 10, DateTimeKind.Local).AddTicks(6226));
        }
    }
}

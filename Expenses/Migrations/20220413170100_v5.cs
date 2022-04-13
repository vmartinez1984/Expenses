using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Expenses.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegister",
                value: new DateTime(2022, 4, 13, 12, 1, 0, 32, DateTimeKind.Local).AddTicks(4081));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegister",
                value: new DateTime(2022, 4, 13, 12, 1, 0, 32, DateTimeKind.Local).AddTicks(4440));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegister",
                value: new DateTime(2022, 4, 13, 12, 1, 0, 32, DateTimeKind.Local).AddTicks(4446));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateRegister",
                value: new DateTime(2022, 4, 13, 12, 1, 0, 32, DateTimeKind.Local).AddTicks(4452));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateRegister",
                value: new DateTime(2022, 4, 13, 12, 1, 0, 32, DateTimeKind.Local).AddTicks(4457));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateRegister",
                value: new DateTime(2022, 4, 13, 12, 1, 0, 32, DateTimeKind.Local).AddTicks(4462));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateRegister",
                value: new DateTime(2022, 4, 13, 12, 1, 0, 32, DateTimeKind.Local).AddTicks(4467));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateRegister",
                value: new DateTime(2022, 4, 13, 12, 1, 0, 32, DateTimeKind.Local).AddTicks(4472));

            migrationBuilder.UpdateData(
                table: "DepositPlan",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateRegister",
                value: new DateTime(2022, 4, 13, 12, 1, 0, 32, DateTimeKind.Local).AddTicks(4477));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseTdc");

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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Expenses.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TermAccount");

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
    }
}

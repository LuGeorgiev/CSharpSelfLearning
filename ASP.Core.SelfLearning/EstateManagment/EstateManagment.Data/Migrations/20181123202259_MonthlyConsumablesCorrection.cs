using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstateManagment.Data.Migrations
{
    public partial class MonthlyConsumablesCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonthlyPaymentConsumables_RentAgreements_RentAgreementId",
                table: "MonthlyPaymentConsumables");

            migrationBuilder.DropForeignKey(
                name: "FK_MonthlyPaymentConsumables_AspNetUsers_UserId",
                table: "MonthlyPaymentConsumables");

            migrationBuilder.DropIndex(
                name: "IX_MonthlyPaymentConsumables_UserId",
                table: "MonthlyPaymentConsumables");

            migrationBuilder.DropColumn(
                name: "PaidOn",
                table: "MonthlyPaymentConsumables");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MonthlyPaymentConsumables");

            migrationBuilder.AlterColumn<int>(
                name: "RentAgreementId",
                table: "MonthlyPaymentConsumables",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentId",
                table: "MonthlyPaymentConsumables",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlyPaymentConsumables_RentAgreements_RentAgreementId",
                table: "MonthlyPaymentConsumables",
                column: "RentAgreementId",
                principalTable: "RentAgreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonthlyPaymentConsumables_RentAgreements_RentAgreementId",
                table: "MonthlyPaymentConsumables");

            migrationBuilder.AlterColumn<int>(
                name: "RentAgreementId",
                table: "MonthlyPaymentConsumables",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PaymentId",
                table: "MonthlyPaymentConsumables",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaidOn",
                table: "MonthlyPaymentConsumables",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MonthlyPaymentConsumables",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyPaymentConsumables_UserId",
                table: "MonthlyPaymentConsumables",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlyPaymentConsumables_RentAgreements_RentAgreementId",
                table: "MonthlyPaymentConsumables",
                column: "RentAgreementId",
                principalTable: "RentAgreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlyPaymentConsumables_AspNetUsers_UserId",
                table: "MonthlyPaymentConsumables",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

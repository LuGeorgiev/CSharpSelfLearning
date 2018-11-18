using Microsoft.EntityFrameworkCore.Migrations;

namespace EstateManagment.Data.Migrations
{
    public partial class paymentEntitiesChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonthlyPaymentConsumables_RentAgreements_RentAgreementId",
                table: "MonthlyPaymentConsumables");

            migrationBuilder.RenameColumn(
                name: "PaymentDate",
                table: "Payments",
                newName: "PaidOn");

            migrationBuilder.RenameColumn(
                name: "MonthlyPayment",
                table: "MonthlyPaymentRents",
                newName: "TotalPayment");

            migrationBuilder.RenameColumn(
                name: "WaterPrice",
                table: "MonthlyPaymentConsumables",
                newName: "PaymentForWater");

            migrationBuilder.RenameColumn(
                name: "PaymentDate",
                table: "MonthlyPaymentConsumables",
                newName: "PaidOn");

            migrationBuilder.RenameColumn(
                name: "ElectricityPrice",
                table: "MonthlyPaymentConsumables",
                newName: "PaymentForElectricity");

            migrationBuilder.AddColumn<bool>(
                name: "CashPayment",
                table: "Payments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ApplyVAT",
                table: "MonthlyPaymentRents",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "RentAgreementId",
                table: "MonthlyPaymentConsumables",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "MonthlyPaymentConsumables",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyPaymentConsumables_PaymentId",
                table: "MonthlyPaymentConsumables",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlyPaymentConsumables_Payments_PaymentId",
                table: "MonthlyPaymentConsumables",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlyPaymentConsumables_RentAgreements_RentAgreementId",
                table: "MonthlyPaymentConsumables",
                column: "RentAgreementId",
                principalTable: "RentAgreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonthlyPaymentConsumables_Payments_PaymentId",
                table: "MonthlyPaymentConsumables");

            migrationBuilder.DropForeignKey(
                name: "FK_MonthlyPaymentConsumables_RentAgreements_RentAgreementId",
                table: "MonthlyPaymentConsumables");

            migrationBuilder.DropIndex(
                name: "IX_MonthlyPaymentConsumables_PaymentId",
                table: "MonthlyPaymentConsumables");

            migrationBuilder.DropColumn(
                name: "CashPayment",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ApplyVAT",
                table: "MonthlyPaymentRents");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "MonthlyPaymentConsumables");

            migrationBuilder.RenameColumn(
                name: "PaidOn",
                table: "Payments",
                newName: "PaymentDate");

            migrationBuilder.RenameColumn(
                name: "TotalPayment",
                table: "MonthlyPaymentRents",
                newName: "MonthlyPayment");

            migrationBuilder.RenameColumn(
                name: "PaymentForWater",
                table: "MonthlyPaymentConsumables",
                newName: "WaterPrice");

            migrationBuilder.RenameColumn(
                name: "PaymentForElectricity",
                table: "MonthlyPaymentConsumables",
                newName: "ElectricityPrice");

            migrationBuilder.RenameColumn(
                name: "PaidOn",
                table: "MonthlyPaymentConsumables",
                newName: "PaymentDate");

            migrationBuilder.AlterColumn<int>(
                name: "RentAgreementId",
                table: "MonthlyPaymentConsumables",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlyPaymentConsumables_RentAgreements_RentAgreementId",
                table: "MonthlyPaymentConsumables",
                column: "RentAgreementId",
                principalTable: "RentAgreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

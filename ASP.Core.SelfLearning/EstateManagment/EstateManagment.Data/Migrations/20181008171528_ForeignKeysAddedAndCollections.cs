using Microsoft.EntityFrameworkCore.Migrations;

namespace EstateManagment.Data.Migrations
{
    public partial class ForeignKeysAddedAndCollections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_RentAgreements_RentAgreementId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_MonthlyPaymentConsumables_RentAgreements_RentAgreementId",
                table: "MonthlyPaymentConsumables");

            migrationBuilder.DropForeignKey(
                name: "FK_MonthlyPaymentRents_RentAgreements_RentAgreementId",
                table: "MonthlyPaymentRents");

            migrationBuilder.AlterColumn<int>(
                name: "RentAgreementId",
                table: "MonthlyPaymentRents",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RentAgreementId",
                table: "MonthlyPaymentConsumables",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RentAgreementId",
                table: "Contracts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_RentAgreements_RentAgreementId",
                table: "Contracts",
                column: "RentAgreementId",
                principalTable: "RentAgreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlyPaymentConsumables_RentAgreements_RentAgreementId",
                table: "MonthlyPaymentConsumables",
                column: "RentAgreementId",
                principalTable: "RentAgreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlyPaymentRents_RentAgreements_RentAgreementId",
                table: "MonthlyPaymentRents",
                column: "RentAgreementId",
                principalTable: "RentAgreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_RentAgreements_RentAgreementId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_MonthlyPaymentConsumables_RentAgreements_RentAgreementId",
                table: "MonthlyPaymentConsumables");

            migrationBuilder.DropForeignKey(
                name: "FK_MonthlyPaymentRents_RentAgreements_RentAgreementId",
                table: "MonthlyPaymentRents");

            migrationBuilder.AlterColumn<int>(
                name: "RentAgreementId",
                table: "MonthlyPaymentRents",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "RentAgreementId",
                table: "MonthlyPaymentConsumables",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "RentAgreementId",
                table: "Contracts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_RentAgreements_RentAgreementId",
                table: "Contracts",
                column: "RentAgreementId",
                principalTable: "RentAgreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlyPaymentConsumables_RentAgreements_RentAgreementId",
                table: "MonthlyPaymentConsumables",
                column: "RentAgreementId",
                principalTable: "RentAgreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlyPaymentRents_RentAgreements_RentAgreementId",
                table: "MonthlyPaymentRents",
                column: "RentAgreementId",
                principalTable: "RentAgreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

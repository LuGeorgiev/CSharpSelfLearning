using Microsoft.EntityFrameworkCore.Migrations;

namespace EstateManagment.Data.Migrations
{
    public partial class ImplementFKsOnPayments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonthlyPaymentConsumables_Payments_PaymentId",
                table: "MonthlyPaymentConsumables");

            migrationBuilder.DropIndex(
                name: "IX_MonthlyPaymentConsumables_PaymentId",
                table: "MonthlyPaymentConsumables");

            migrationBuilder.AddColumn<int>(
                name: "MonthlyPaymentConsumableId",
                table: "Payments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_MonthlyPaymentConsumableId",
                table: "Payments",
                column: "MonthlyPaymentConsumableId",
                unique: true,
                filter: "[MonthlyPaymentConsumableId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_MonthlyPaymentConsumables_MonthlyPaymentConsumableId",
                table: "Payments",
                column: "MonthlyPaymentConsumableId",
                principalTable: "MonthlyPaymentConsumables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_MonthlyPaymentConsumables_MonthlyPaymentConsumableId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_MonthlyPaymentConsumableId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "MonthlyPaymentConsumableId",
                table: "Payments");

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
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace EstateManagment.Data.Migrations
{
    public partial class InvoiceNumberIncluded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceNumber",
                table: "MonthlyPaymentRents",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceNumber",
                table: "MonthlyPaymentConsumables",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceNumber",
                table: "MonthlyPaymentRents");

            migrationBuilder.DropColumn(
                name: "InvoiceNumber",
                table: "MonthlyPaymentConsumables");
        }
    }
}

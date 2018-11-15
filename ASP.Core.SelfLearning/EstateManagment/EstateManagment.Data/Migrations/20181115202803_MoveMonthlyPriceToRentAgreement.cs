using Microsoft.EntityFrameworkCore.Migrations;

namespace EstateManagment.Data.Migrations
{
    public partial class MoveMonthlyPriceToRentAgreement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonthlyPrice",
                table: "PropertyRents");

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyPrice",
                table: "RentAgreements",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonthlyPrice",
                table: "RentAgreements");

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyPrice",
                table: "PropertyRents",
                nullable: false,
                defaultValue: 0m);
        }
    }
}

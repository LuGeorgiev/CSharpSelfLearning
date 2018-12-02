using Microsoft.EntityFrameworkCore.Migrations;

namespace EstateManagment.Data.Migrations
{
    public partial class ParkingSlotAreaIncluded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Area",
                table: "ParkingSlots",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "ParkingSlots");
        }
    }
}

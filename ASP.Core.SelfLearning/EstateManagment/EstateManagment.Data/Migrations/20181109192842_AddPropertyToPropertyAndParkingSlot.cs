using Microsoft.EntityFrameworkCore.Migrations;

namespace EstateManagment.Data.Migrations
{
    public partial class AddPropertyToPropertyAndParkingSlot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActual",
                table: "Properties",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActual",
                table: "ParkingSlots",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActual",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "IsActual",
                table: "ParkingSlots");
        }
    }
}

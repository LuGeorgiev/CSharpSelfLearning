using Microsoft.EntityFrameworkCore.Migrations;

namespace CamaraBazar.Data.Migrations
{
    public partial class lightMeteringS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LightMeterings",
                table: "Cameras",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LightMeterings",
                table: "Cameras");
        }
    }
}

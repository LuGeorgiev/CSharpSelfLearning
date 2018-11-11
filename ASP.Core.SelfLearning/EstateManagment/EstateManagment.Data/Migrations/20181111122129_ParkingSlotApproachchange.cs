using Microsoft.EntityFrameworkCore.Migrations;

namespace EstateManagment.Data.Migrations
{
    public partial class ParkingSlotApproachchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSlots_Companies_CompanyId",
                table: "ParkingSlots");

            migrationBuilder.DropTable(
                name: "ParkingSlotRents");

            migrationBuilder.DropColumn(
                name: "IsActual",
                table: "ParkingSlots");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "ParkingSlots",
                newName: "RentAgreementId");

            migrationBuilder.RenameIndex(
                name: "IX_ParkingSlots_CompanyId",
                table: "ParkingSlots",
                newName: "IX_ParkingSlots_RentAgreementId");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ParkingSlots",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSlots_RentAgreements_RentAgreementId",
                table: "ParkingSlots",
                column: "RentAgreementId",
                principalTable: "RentAgreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSlots_RentAgreements_RentAgreementId",
                table: "ParkingSlots");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ParkingSlots");

            migrationBuilder.RenameColumn(
                name: "RentAgreementId",
                table: "ParkingSlots",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_ParkingSlots_RentAgreementId",
                table: "ParkingSlots",
                newName: "IX_ParkingSlots_CompanyId");

            migrationBuilder.AddColumn<bool>(
                name: "IsActual",
                table: "ParkingSlots",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ParkingSlotRents",
                columns: table => new
                {
                    ParkingSlotId = table.Column<int>(nullable: false),
                    RentAgreementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSlotRents", x => new { x.ParkingSlotId, x.RentAgreementId });
                    table.ForeignKey(
                        name: "FK_ParkingSlotRents_ParkingSlots_ParkingSlotId",
                        column: x => x.ParkingSlotId,
                        principalTable: "ParkingSlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParkingSlotRents_RentAgreements_RentAgreementId",
                        column: x => x.RentAgreementId,
                        principalTable: "RentAgreements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSlotRents_RentAgreementId",
                table: "ParkingSlotRents",
                column: "RentAgreementId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSlots_Companies_CompanyId",
                table: "ParkingSlots",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

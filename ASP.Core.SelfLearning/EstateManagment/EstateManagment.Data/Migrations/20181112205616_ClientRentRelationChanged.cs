using Microsoft.EntityFrameworkCore.Migrations;

namespace EstateManagment.Data.Migrations
{
    public partial class ClientRentRelationChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientRents");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "RentAgreements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActual",
                table: "RentAgreements",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_RentAgreements_ClientId",
                table: "RentAgreements",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentAgreements_Clients_ClientId",
                table: "RentAgreements",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentAgreements_Clients_ClientId",
                table: "RentAgreements");

            migrationBuilder.DropIndex(
                name: "IX_RentAgreements_ClientId",
                table: "RentAgreements");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "RentAgreements");

            migrationBuilder.DropColumn(
                name: "IsActual",
                table: "RentAgreements");

            migrationBuilder.CreateTable(
                name: "ClientRents",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false),
                    RentAgreementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientRents", x => new { x.ClientId, x.RentAgreementId });
                    table.ForeignKey(
                        name: "FK_ClientRents_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientRents_RentAgreements_RentAgreementId",
                        column: x => x.RentAgreementId,
                        principalTable: "RentAgreements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientRents_RentAgreementId",
                table: "ClientRents",
                column: "RentAgreementId");
        }
    }
}

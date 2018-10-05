using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstateManagment.Data.Migrations
{
    public partial class EntitiesWithProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Bulstat = table.Column<string>(nullable: true),
                    AccountableName = table.Column<string>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Bulstat = table.Column<string>(nullable: true),
                    AccountablePerson = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentAgreements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ParkingSlotDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentAgreements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSlots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingSlots_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Area = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UploadData = table.Column<DateTime>(nullable: false),
                    ScannedContract = table.Column<byte[]>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RentAgreementId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_RentAgreements_RentAgreementId",
                        column: x => x.RentAgreementId,
                        principalTable: "RentAgreements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyPaymentConsumables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WaterReport = table.Column<int>(nullable: true),
                    WaterPrice = table.Column<decimal>(nullable: false),
                    ElectricityDay = table.Column<int>(nullable: true),
                    ElectricityNight = table.Column<int>(nullable: true),
                    ElectricityPeak = table.Column<int>(nullable: true),
                    ElectricityPrice = table.Column<decimal>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeadLine = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    PaymentDate = table.Column<DateTime>(nullable: true),
                    RentAgreementId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyPaymentConsumables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonthlyPaymentConsumables_RentAgreements_RentAgreementId",
                        column: x => x.RentAgreementId,
                        principalTable: "RentAgreements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MonthlyPaymentConsumables_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyPaymentRents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeadLine = table.Column<DateTime>(nullable: false),
                    MonthlyPayment = table.Column<decimal>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    RentAgreementId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyPaymentRents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonthlyPaymentRents_RentAgreements_RentAgreementId",
                        column: x => x.RentAgreementId,
                        principalTable: "RentAgreements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "PropertyRents",
                columns: table => new
                {
                    PropertyId = table.Column<int>(nullable: false),
                    RentAgreementId = table.Column<int>(nullable: false),
                    MonthlyPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyRents", x => new { x.PropertyId, x.RentAgreementId });
                    table.ForeignKey(
                        name: "FK_PropertyRents_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyRents_RentAgreements_RentAgreementId",
                        column: x => x.RentAgreementId,
                        principalTable: "RentAgreements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    MonthlyPaymentRentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_MonthlyPaymentRents_MonthlyPaymentRentId",
                        column: x => x.MonthlyPaymentRentId,
                        principalTable: "MonthlyPaymentRents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientRents_RentAgreementId",
                table: "ClientRents",
                column: "RentAgreementId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_RentAgreementId",
                table: "Contracts",
                column: "RentAgreementId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyPaymentConsumables_RentAgreementId",
                table: "MonthlyPaymentConsumables",
                column: "RentAgreementId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyPaymentConsumables_UserId",
                table: "MonthlyPaymentConsumables",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyPaymentRents_RentAgreementId",
                table: "MonthlyPaymentRents",
                column: "RentAgreementId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSlotRents_RentAgreementId",
                table: "ParkingSlotRents",
                column: "RentAgreementId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSlots_CompanyId",
                table: "ParkingSlots",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_MonthlyPaymentRentId",
                table: "Payments",
                column: "MonthlyPaymentRentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_CompanyId",
                table: "Properties",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyRents_RentAgreementId",
                table: "PropertyRents",
                column: "RentAgreementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientRents");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "MonthlyPaymentConsumables");

            migrationBuilder.DropTable(
                name: "ParkingSlotRents");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PropertyRents");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ParkingSlots");

            migrationBuilder.DropTable(
                name: "MonthlyPaymentRents");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "RentAgreements");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}

﻿// <auto-generated />
using System;
using EstateManagment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EstateManagment.Data.Migrations
{
    [DbContext(typeof(EstateManagmentContext))]
    partial class EsteteManagmentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EstateManagment.Data.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountableName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Bulstat")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("EGN")
                        .HasMaxLength(10);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Notes")
                        .HasMaxLength(500);

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("EstateManagment.Data.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountablePerson")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Bulstat")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("EstateManagment.Data.Models.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("RentAgreementId");

                    b.Property<byte[]>("ScannedContract")
                        .IsRequired()
                        .HasMaxLength(2097152);

                    b.Property<DateTime>("UploadDate");

                    b.HasKey("Id");

                    b.HasIndex("RentAgreementId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("EstateManagment.Data.Models.MonthlyPaymentConsumable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("DeadLine");

                    b.Property<int?>("ElectricityDay");

                    b.Property<int?>("ElectricityNight");

                    b.Property<int?>("ElectricityPeak");

                    b.Property<DateTime?>("PaidOn");

                    b.Property<decimal>("PaymentForElectricity");

                    b.Property<decimal>("PaymentForWater");

                    b.Property<int>("PaymentId");

                    b.Property<int?>("RentAgreementId");

                    b.Property<string>("UserId");

                    b.Property<int?>("WaterReport");

                    b.HasKey("Id");

                    b.HasIndex("RentAgreementId");

                    b.HasIndex("UserId");

                    b.ToTable("MonthlyPaymentConsumables");
                });

            modelBuilder.Entity("EstateManagment.Data.Models.MonthlyPaymentRent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ApplyVAT");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("DeadLine");

                    b.Property<bool>("IsPaid");

                    b.Property<int>("RentAgreementId");

                    b.Property<decimal>("TotalPayment");

                    b.HasKey("Id");

                    b.HasIndex("RentAgreementId");

                    b.ToTable("MonthlyPaymentRents");
                });

            modelBuilder.Entity("EstateManagment.Data.Models.ParkingSlot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.Property<int>("RentAgreementId");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("RentAgreementId");

                    b.ToTable("ParkingSlots");
                });

            modelBuilder.Entity("EstateManagment.Data.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<bool>("CashPayment");

                    b.Property<int?>("MonthlyPaymentConsumableId");

                    b.Property<int?>("MonthlyPaymentRentId");

                    b.Property<DateTime>("PaidOn");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("MonthlyPaymentConsumableId")
                        .IsUnique()
                        .HasFilter("[MonthlyPaymentConsumableId] IS NOT NULL");

                    b.HasIndex("MonthlyPaymentRentId");

                    b.HasIndex("UserId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("EstateManagment.Data.Models.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("Area");

                    b.Property<int>("CompanyId");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<bool>("IsActual");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("EstateManagment.Data.Models.PropertyRent", b =>
                {
                    b.Property<int>("PropertyId");

                    b.Property<int>("RentAgreementId");

                    b.HasKey("PropertyId", "RentAgreementId");

                    b.HasIndex("RentAgreementId");

                    b.ToTable("PropertyRents");
                });

            modelBuilder.Entity("EstateManagment.Data.Models.RentAgreement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<DateTime?>("EndDate");

                    b.Property<bool>("IsActual");

                    b.Property<decimal>("MonthlyPrice");

                    b.Property<string>("ParkingSlotDescription")
                        .HasMaxLength(500);

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("RentAgreements");
                });

            modelBuilder.Entity("EstateManagment.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Nickname")
                        .HasMaxLength(100);

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("EstateManagment.Data.Models.Contract", b =>
                {
                    b.HasOne("EstateManagment.Data.Models.RentAgreement", "RentAgreement")
                        .WithMany("Contracts")
                        .HasForeignKey("RentAgreementId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EstateManagment.Data.Models.MonthlyPaymentConsumable", b =>
                {
                    b.HasOne("EstateManagment.Data.Models.RentAgreement")
                        .WithMany("MonthlyConsumables")
                        .HasForeignKey("RentAgreementId");

                    b.HasOne("EstateManagment.Data.Models.User", "User")
                        .WithMany("SubmittedConsumablePayments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EstateManagment.Data.Models.MonthlyPaymentRent", b =>
                {
                    b.HasOne("EstateManagment.Data.Models.RentAgreement", "RentAgreement")
                        .WithMany("MonthlyRents")
                        .HasForeignKey("RentAgreementId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EstateManagment.Data.Models.ParkingSlot", b =>
                {
                    b.HasOne("EstateManagment.Data.Models.RentAgreement", "RentAgreement")
                        .WithMany("ParkingSlots")
                        .HasForeignKey("RentAgreementId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EstateManagment.Data.Models.Payment", b =>
                {
                    b.HasOne("EstateManagment.Data.Models.MonthlyPaymentConsumable", "MonthlyPaymentConsumable")
                        .WithOne("Payment")
                        .HasForeignKey("EstateManagment.Data.Models.Payment", "MonthlyPaymentConsumableId");

                    b.HasOne("EstateManagment.Data.Models.MonthlyPaymentRent", "MonthlyPaymentRent")
                        .WithMany("Payments")
                        .HasForeignKey("MonthlyPaymentRentId");

                    b.HasOne("EstateManagment.Data.Models.User", "User")
                        .WithMany("SubmittedRentPayments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EstateManagment.Data.Models.Property", b =>
                {
                    b.HasOne("EstateManagment.Data.Models.Company", "Company")
                        .WithMany("Properties")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EstateManagment.Data.Models.PropertyRent", b =>
                {
                    b.HasOne("EstateManagment.Data.Models.Property", "Property")
                        .WithMany("PropertyRents")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EstateManagment.Data.Models.RentAgreement", "RentAgreement")
                        .WithMany("PropertyRents")
                        .HasForeignKey("RentAgreementId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EstateManagment.Data.Models.RentAgreement", b =>
                {
                    b.HasOne("EstateManagment.Data.Models.Client", "Client")
                        .WithMany("RentAgreements")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EstateManagment.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EstateManagment.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EstateManagment.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EstateManagment.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

﻿using EstateManagment.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EstateManagment.Data
{
    public class EstateManagmentContext : IdentityDbContext<User>
    {
        public EstateManagmentContext(DbContextOptions<EstateManagmentContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients{ get; set; }

        public DbSet<Company> Companies{ get; set; }

        public DbSet<Contract> Contracts{ get; set; }

        public DbSet<MonthlyPaymentConsumable> MonthlyPaymentConsumables{ get; set; }

        public DbSet<MonthlyPaymentRent> MonthlyPaymentRents{ get; set; }

        public DbSet<ParkingSlot> ParkingSlots{ get; set; }

        public DbSet<Payment> Payments{ get; set; }

        public DbSet<Property> Properties{ get; set; }

        public DbSet<PropertyRent> PropertyRents{ get; set; }

        public DbSet<RentAgreement> RentAgreements{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PropertyRent>()
                .HasKey(pr => new { pr.PropertyId, pr.RentAgreementId });

            builder.Entity<MonthlyPaymentConsumable>()
                .HasOne(mc => mc.Payment)
                .WithOne(p => p.MonthlyPaymentConsumable)
                .HasForeignKey<Payment>(mc => mc.MonthlyPaymentConsumableId);

            builder.Entity<Client>()
                .HasIndex(c => c.Name)
                .IsUnique();


            base.OnModelCreating(builder);
        }
    }
}

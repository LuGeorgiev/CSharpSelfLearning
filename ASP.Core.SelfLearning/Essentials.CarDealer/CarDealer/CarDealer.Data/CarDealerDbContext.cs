

namespace CarDealer.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using CarDealer.Data.Models;

    public class CarDealerDbContext : IdentityDbContext<User>
    {
        public CarDealerDbContext(DbContextOptions<CarDealerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartCar> PartCars { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PartCar>()
                .HasKey(pc=>new { pc.CarId, pc.PartId});

            builder.Entity<PartCar>()
                .HasOne(x => x.Car)
                .WithMany(x => x.Parts)
                .HasForeignKey(x => x.CarId);

            builder.Entity<PartCar>()
                .HasOne(x => x.Part)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.PartId);

            builder.Entity<Part>()
                .HasOne(x => x.Supplier)
                .WithMany(x => x.Parts)
                .HasForeignKey(x => x.SupplierId);

            builder.Entity<Sale>()
                .HasOne(x => x.Car)
                .WithMany(x => x.Sales)
                .HasForeignKey(x => x.CarId);
        
            builder.Entity<Sale>()
                .HasOne(x => x.Customer)
                .WithMany(x => x.Sales)
                .HasForeignKey(x => x.CustomerId);

            base.OnModelCreating(builder);          
        }
    }
}

namespace CamaraBazar.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class CameraBazarDbContext : IdentityDbContext<User>
    {
        public CameraBazarDbContext(DbContextOptions<CameraBazarDbContext> options)
            : base(options)
        {
        }

        public DbSet<Camera> Cameras { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<User>()
                .HasMany(u => u.Camers)
                .WithOne(u => u.User)
                .HasForeignKey(c => c.UserId);           

            base.OnModelCreating(builder);
        }
    }
}

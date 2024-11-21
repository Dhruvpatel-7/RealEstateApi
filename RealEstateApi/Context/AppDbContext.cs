using Microsoft.EntityFrameworkCore;
using RealEstateApi.Models;

namespace RealEstateApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Properties> Properties { get; set; }
        public DbSet<Favourite> Favourite { get; set; }
        public DbSet<Subscription> Subscription { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("users");

            modelBuilder.Entity<Properties>()
                .ToTable("properties");

            modelBuilder.Entity<Favourite>()
                .ToTable("Favourite");

            modelBuilder.Entity<Subscription>()
                .ToTable("Subscription");
        }
    }
}

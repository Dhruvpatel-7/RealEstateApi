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
        public DbSet<Inquiry> Inquiry { get; set; }
        public DbSet<Contactus> Contactus { get; set; }
        public DbSet<Report> Report { get; set; }
        public DbSet<Gallary> Gallary { get; set; }
        public DbSet<Feedback> Feedback { get; set; }



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

            modelBuilder.Entity<Gallary>()
                .ToTable("Gallary");

            modelBuilder.Entity<Report>()
                .ToTable("Report");

            modelBuilder.Entity<Contactus>()
                .ToTable("Contactus");

            modelBuilder.Entity<Inquiry>()
                .ToTable("Inquiry");

            modelBuilder.Entity<Feedback>()
                .ToTable("Feedback");
        }
    }
}

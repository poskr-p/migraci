using Microsoft.EntityFrameworkCore;
using migraci.Models;
using Microsoft.Extensions.Configuration;
using System;
using migraci.Models;
using migraci;

namespace migraci
{
    public class CarSalesDbContext : DbContext
    {
        public CarSalesDbContext() { }

        public CarSalesDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<CarFeature> CarFeatures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .AddUserSecrets<Program>()
                    .Build();

                var connectionString = configuration.GetConnectionString("PostgreConnection");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Настройка составного первичного ключа для CarFeature
            modelBuilder.Entity<CarFeature>()
                .HasKey(cf => new { cf.CarId, cf.FeatureId });

            // Настройка связей для CarFeature
            modelBuilder.Entity<CarFeature>()
                .HasOne(cf => cf.Car)
                .WithMany(c => c.CarFeatures)
                .HasForeignKey(cf => cf.CarId);

            modelBuilder.Entity<CarFeature>()
                .HasOne(cf => cf.Feature)
                .WithMany(f => f.CarFeatures)
                .HasForeignKey(cf => cf.FeatureId);
        }
    }
}
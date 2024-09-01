using Microsoft.EntityFrameworkCore;
using TestTask.Domain.Entites;

namespace SecondTask.Infrastructure.DbContext;

public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Location> Locations { get; set; }
    public DbSet<WeatherData> WeatherData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>()
            .Property(i => i.CountryCode)
            .HasMaxLength(2);

        modelBuilder.Entity<Location>()
            .Property(i => i.CityName)
            .HasMaxLength(50);

        // modelBuilder.Entity<WeatherData>()
        //     .Property(i => i.TemperatureInCelsius)
        //     .HasPrecision(3, 2);  for test 
    }
}
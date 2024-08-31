using Microsoft.EntityFrameworkCore;
using TestTask.Domain.Entites;

namespace SecondTask.Infrastructure.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<WeatherData> WeatherData { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .Property(i => i.CountryCode)
                .HasMaxLength(2);
                
            modelBuilder.Entity<Location>()
                .Property(i => i.Name)
                .HasMaxLength(50);
            
            modelBuilder.Entity<WeatherData>()
                .Property(i => i.Temperature)
                .HasPrecision(5, 2); 
        }
    }
}

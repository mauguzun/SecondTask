namespace TestTask.Domain.Entites;

public class WeatherData : Entity
{
    public Location Location { get; set; }
    public decimal TemperatureInCelsius { get; set; }

    public int LocationId { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
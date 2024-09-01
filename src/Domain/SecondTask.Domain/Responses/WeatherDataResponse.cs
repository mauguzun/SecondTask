namespace TestTask.Domain.Responses;

public class WeatherDataResponse
{
    public int Id { get; set; }
    public string CityName { get; set; }
    public string CountryCode { get; set; }
    public decimal TemperatureInCelsius { get; set; }
    public int LocationId { get; set; }
    public DateTime Timestamp { get; set; }
}
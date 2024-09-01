namespace TestTask.Domain.Entites;

public class Location : Entity
{
    public string CityName { get; set; }
    public string CountryCode { get; set; }

    public List<WeatherData> WeatherData { get; set; } = new();
}
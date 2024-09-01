using AutoMapper;
using SecondTask.Infrastructure.Inerfaces.Repositories;
using SecondTask.Infrastructure.Inerfaces.Services;
using TestTask.Application.Inerfaces;
using TestTask.Domain.Entites;
using TestTask.Domain.Responses;

namespace TestTask.Application.Implementations;

public class WeatherService : IWeatherService
{
    private readonly ILocationRepository _locationRepository;
    private readonly IMapper _mapper;
    private readonly IOpenWeatherService _openWeatherService;
    private readonly IWeatherDataRepostiory _weatherDataRepository;

    public WeatherService(IOpenWeatherService openWeatherService, ILocationRepository locationRepository,
        IWeatherDataRepostiory weatherDataRepository, IMapper mapper)
    {
        _openWeatherService = openWeatherService;
        _locationRepository = locationRepository;
        _weatherDataRepository = weatherDataRepository;
        _mapper = mapper;
    }

    public async Task<List<WeatherDataResponse>> GetWeatherLogsAsync(CancellationToken cancellationToken)
    {
        var weatherLogs = await _weatherDataRepository.GetAsync(cancellationToken);
        return _mapper.Map<List<WeatherDataResponse>>(weatherLogs);
    }

    public async Task FetchAndStoreWeatherDataAsync(CancellationToken cancellationToken)
    {
        var timestamp = DateTime.UtcNow;
        var locations = await _locationRepository.GetAsync(cancellationToken);
        var weatherDataTasks = locations.Select(async loc =>
        {
            var openWeather =
                await _openWeatherService.GetWeatherAsync($"{loc.CityName},{loc.CountryCode}", cancellationToken);
            return openWeather is not null
                ? new WeatherData
                {
                    LocationId = loc.Id,
                    TemperatureInCelsius = openWeather.Main.Temp,
                    Timestamp = timestamp
                }
                : null;
        });

        var weatherData = (await Task.WhenAll(weatherDataTasks)).Where(w => w != null).Select(w => w!).ToList();
        await _weatherDataRepository.AddRangeAsync(weatherData, cancellationToken);
        await _weatherDataRepository.SaveChangesAsync(cancellationToken);
    }
}
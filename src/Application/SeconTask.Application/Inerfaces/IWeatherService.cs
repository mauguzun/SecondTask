using TestTask.Domain.Responses;

namespace TestTask.Application.Inerfaces;

public interface IWeatherService
{
    Task FetchAndStoreWeatherDataAsync(CancellationToken cancellationToken);

    Task<List<WeatherDataResponse>> GetWeatherLogsAsync(CancellationToken cancellationToken);
}
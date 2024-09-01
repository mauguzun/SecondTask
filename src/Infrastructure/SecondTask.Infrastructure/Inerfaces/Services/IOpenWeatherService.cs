using TestTask.Domain.Responses;

namespace SecondTask.Infrastructure.Inerfaces.Services;

public interface IOpenWeatherService
{
    public Task<OpenWeatherResponse?> GetWeatherAsync(string location, CancellationToken cancellationToken);
}
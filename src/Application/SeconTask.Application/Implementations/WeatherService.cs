using System.Globalization;
using System.Net;
using OneOf;
using SecondTask.Infrastructure.Inerfaces.Services;
using TestTask.Application.Inerfaces;

namespace TestTask.Application.Implementations
{
    public class WeatherService : IWeatherService
    {
        private readonly IOpenWeatherService _openWeatherService;

        public WeatherService(IOpenWeatherService openWeatherService) =>
            (_openWeatherService ) = (openWeatherService);

        public async Task FetchAndStoreWeatherDataAsync(string location, CancellationToken cancellationToken)
        {
            var httpResponse = await _openWeatherService.GetWeatherAsync(location, cancellationToken);
        }

    }
}

using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using SecondTask.Infrastructure.Inerfaces.Services;
using TestTask.Domain.Responses;

namespace SecondTask.Infrastructure.Implementations.Services
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private readonly string _apiKey;
        private readonly int _timeout;
        public OpenWeatherService(IConfiguration configuration)=>
            (_apiKey, _timeout) = (configuration["ApiKey"], configuration.GetValue<int>("HttpClientTimeout"));

        public async Task<OpenWeatherResponse?> GetWeatherAsync(string location, CancellationToken cancellationToken)
        {
            using HttpClient client = new HttpClient() { Timeout = TimeSpan.FromSeconds(_timeout) };
            var response =  await  client.GetFromJsonAsync<OpenWeatherResponse>($"https://api.openweathermap.org/data/2.5/weather?q={location}&appid={_apiKey}&units=metric", cancellationToken);
           
            return response;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TestTask.Application.Inerfaces;
using TestTask.Domain.Responses;

namespace SecondTask.Web.Server.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("[controller]")]
public class WeatherDataController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    public WeatherDataController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    /// <summary>
    ///     Retrieves the list WeatherDataResponse
    /// </summary>
    /// <returns>A list of WeatherDataResponse.</returns>
    /// <response code="200">Returns the list of WeatherDataResponse .</response>
    /// <response code="500">Returns an error if an exception occurs.</response>
    [HttpGet(Name = "GetWeatherLogsAsync")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<WeatherDataResponse>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IList<WeatherDataResponse>> GetWeatherLogs(CancellationToken cancellationToken)
    {
        var latestSearches = await _weatherService.GetWeatherLogsAsync(cancellationToken);
        return latestSearches;
    }
}
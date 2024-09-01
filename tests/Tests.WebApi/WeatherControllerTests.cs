using Moq;
using SecondTask.Web.Server.Controllers;
using TestTask.Application.Inerfaces;
using TestTask.Domain.Responses;

namespace Tests.WebApi;

[TestClass]
public class WeatherControllerTests
{
    private WeatherDataController _controller;
    private Mock<IWeatherService> _mockMovieService;

    [TestInitialize]
    public void Setup()
    {
        _mockMovieService = new Mock<IWeatherService>();
        _controller = new WeatherDataController(_mockMovieService.Object);
    }

    [TestMethod]
    public async Task MakeRequest_ValidResult()
    {
        //Assert
        var expectedResult = new List<WeatherDataResponse> { new() { CityName = "Riga" } };
        _mockMovieService.Setup(s => s.GetWeatherLogsAsync(CancellationToken.None)).ReturnsAsync(expectedResult);
        // Act
        var result = await _controller.GetWeatherLogs(CancellationToken.None);
        // Arrange
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(List<WeatherDataResponse>));
        Assert.AreEqual(result, expectedResult);
    }
}
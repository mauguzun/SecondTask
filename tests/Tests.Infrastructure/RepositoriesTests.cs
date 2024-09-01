using Microsoft.EntityFrameworkCore;
using SecondTask.Infrastructure.DbContext;
using SecondTask.Infrastructure.Implementations.Repositories;
using TestTask.Domain.Entites;

namespace Tests.Infrastructure;

[TestClass]
public class RepositoriesTests
{
    private readonly TestDbContext _dbContext;

    public RepositoriesTests()
    {
        _dbContext = new TestDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("TestDatabase").Options);
    }


    [TestMethod]
    public async Task AddRangeAsync_GetAsync_Valid()
    {
        //Assert
        var location = new Location { CountryCode = "AU", CityName = "Sin City" };
        _dbContext.Locations.Add(location);
        await _dbContext.SaveChangesAsync();

        var weatherData = new WeatherData
        {
            TemperatureInCelsius = 11.1m,
            LocationId = location.Id
        };
        //Act
        var weatherDataRepository = new WeatherDataRepostiory(_dbContext);
        await weatherDataRepository.AddRangeAsync(new List<WeatherData> { weatherData }, default);
        await weatherDataRepository.SaveChangesAsync(default);

        var response = await weatherDataRepository.GetAsync(default);

        // Arrange
        Assert.AreEqual(11.1m, response.First().TemperatureInCelsius, "TemperatureInCelsius not equal");
        Assert.AreEqual(location.Id, response.First().LocationId, "LocationId not equal");
    }
}
using Microsoft.EntityFrameworkCore;
using SecondTask.Infrastructure.DbContext;
using SecondTask.Infrastructure.Inerfaces.Repositories;
using TestTask.Domain.Entites;

namespace SecondTask.Infrastructure.Implementations.Repositories;

public class WeatherDataRepostiory : GenericRepository<WeatherData>, IWeatherDataRepostiory
{
    private const int MaxLogPerRequest = 1000;

    public WeatherDataRepostiory(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public new async Task<List<WeatherData>> GetAsync(CancellationToken cancellationToken)
    {
        return await DbContext.WeatherData
            .Include(w => w.Location)
            .OrderBy(w => w.Timestamp)
            .Take(MaxLogPerRequest)
            .ToListAsync(cancellationToken);
    }
}
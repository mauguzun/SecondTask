using Microsoft.EntityFrameworkCore;
using SecondTask.Infrastructure.DbContext;
using TestTask.Domain.Entites;

namespace SecondTask.Infrastructure.Implementations.Repositories;

public class WeatherDataRepostiory : GenericRepository<WeatherData>
{
    public WeatherDataRepostiory(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<WeatherData>> GetAsync()=>
        await DbContext.WeatherData
            .Include(w => w.Location) 
            .ToListAsync();
}
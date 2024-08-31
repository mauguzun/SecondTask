using SecondTask.Infrastructure.DbContext;
using TestTask.Domain.Entites;

namespace SecondTask.Infrastructure.Implementations.Repositories;

public class LocationRepository : GenericRepository<Location>
{
    public LocationRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
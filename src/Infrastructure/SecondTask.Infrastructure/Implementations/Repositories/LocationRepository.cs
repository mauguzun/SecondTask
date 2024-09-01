using SecondTask.Infrastructure.DbContext;
using SecondTask.Infrastructure.Inerfaces.Repositories;
using TestTask.Domain.Entites;

namespace SecondTask.Infrastructure.Implementations.Repositories;

public class LocationRepository : GenericRepository<Location> , ILocationRepository
{
    public LocationRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
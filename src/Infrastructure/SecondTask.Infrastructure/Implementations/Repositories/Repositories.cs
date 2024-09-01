using SecondTask.Infrastructure.DbContext;
using SecondTask.Infrastructure.Inerfaces.Repositories;
using TestTask.Domain.Entites;

namespace SecondTask.Infrastructure.Implementations.Repositories;

public class Repositories : GenericRepository<Location>, ILocationRepository
{
    public Repositories(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
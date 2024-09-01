using TestTask.Domain.Entites;

namespace SecondTask.Infrastructure.Inerfaces.Repositories;

public interface IGenericRepository<TEntity> where TEntity : Entity
{
    Task AddRangeAsync(List<TEntity> entities, CancellationToken cancellationToken);
    Task<List<TEntity>> GetAsync(CancellationToken cancellationToken);
    Task<TEntity?> GetByAsync(int id, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
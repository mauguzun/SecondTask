using TestTask.Domain.Entites;

namespace SecondTask.Infrastructure.Inerfaces.Repositories;
public interface IGenericRepository<TEntity> where TEntity : Entity
{
    Task AddAsync(TEntity entity);
    Task<List<TEntity>> GetAsync();
    Task<TEntity?> GetByAsync(int id);
    Task SaveChangesAsync();
}

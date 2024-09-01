using Microsoft.EntityFrameworkCore;
using SecondTask.Infrastructure.DbContext;
using SecondTask.Infrastructure.Inerfaces.Repositories;
using TestTask.Domain.Entites;

namespace SecondTask.Infrastructure.Implementations.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
{
    protected  ApplicationDbContext DbContext { get; }
    protected GenericRepository(ApplicationDbContext dbContext) => DbContext = dbContext;
   
    public async Task AddRangeAsync(List<TEntity> entities,CancellationToken cancellationToken)
        => await DbContext.Set<TEntity>().AddRangeAsync(entities,cancellationToken);
    public async Task<List<TEntity>> GetAsync(CancellationToken cancellationToken) 
        => await DbContext.Set<TEntity>().ToListAsync(cancellationToken);
    public async Task<TEntity?> GetByAsync(int id,CancellationToken cancellationToken)=> 
        await DbContext.Set<TEntity>().FindAsync(id,cancellationToken);
    public async Task SaveChangesAsync(CancellationToken cancellationToken) => await DbContext.SaveChangesAsync(cancellationToken);
}
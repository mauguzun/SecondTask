using Microsoft.EntityFrameworkCore;
using SecondTask.Infrastructure.DbContext;
using SecondTask.Infrastructure.Inerfaces.Repositories;
using TestTask.Domain.Entites;

namespace SecondTask.Infrastructure.Implementations.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
{
    protected  ApplicationDbContext DbContext { get; }
    protected GenericRepository(ApplicationDbContext dbContext) => DbContext = dbContext;
   
    public async Task AddAsync(TEntity entity)=> await DbContext.Set<TEntity>().AddAsync(entity);
    public async Task<List<TEntity>> GetAsync() => await DbContext.Set<TEntity>().ToListAsync();
    public async Task<TEntity?> GetByAsync(int id)=> await DbContext.Set<TEntity>().FindAsync(id);
    public async Task SaveChangesAsync() => await DbContext.SaveChangesAsync();
}
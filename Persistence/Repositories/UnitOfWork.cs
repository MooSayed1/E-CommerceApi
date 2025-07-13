using System.Collections.Concurrent;
using Domain.Contracts;
using Persistance.Data.Contexts;

namespace Persistance.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;
    public ConcurrentDictionary<string, object> _repositories;

    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _repositories = new();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public IGenericRepo<TEntity, TKey> GetRepo<TEntity, TKey>()
        where TEntity : BaseEntity<TKey>
    {
        return (IGenericRepo<TEntity,TKey>) _repositories.GetOrAdd(typeof(TEntity).Name,(name)=> new GenericRepo<TEntity,TKey>(_dbContext));
    }
}
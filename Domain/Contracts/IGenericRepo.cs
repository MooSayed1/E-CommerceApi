using Domain.Entities;

namespace Domain.Contracts;

public interface IGenericRepo<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    public Task<TEntity?> GetByIdAsync(TKey? id);
    public Task<IEnumerable<TEntity>> GetAllAsync(bool asNoTracking = false);
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
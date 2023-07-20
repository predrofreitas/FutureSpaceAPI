using FutureSpaceAPI.Domain.Entities;

namespace FutureSpaceAPI.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task InsertAsync(TEntity launcher);
        Task InsertInRangeAsync(List<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(Guid id);
        Task DeleteAsync(TEntity entity);
        bool Exists(Guid id);
        Task SaveChangesAsync();
    }
}

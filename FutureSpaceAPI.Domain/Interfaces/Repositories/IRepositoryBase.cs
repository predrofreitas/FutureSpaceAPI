using FutureSpaceAPI.Domain.Entities;

namespace FutureSpaceAPI.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : Entity
    {
        Task InsertAsync(TEntity launcher);
        Task<TEntity> GetByIdAsync(int id);
        Task DeleteAsync(TEntity entity);
        bool Exists(int id);
        Task<List<TEntity>> GetEntitiesPagedAsync(int page, int pageSize);
        Task SaveChangesAsync();
    }
}

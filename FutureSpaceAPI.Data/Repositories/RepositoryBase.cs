using FutureSpaceAPI.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FutureSpaceAPI.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly ApplicationDbContext _appDbContext;

        public RepositoryBase(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = appDbContext.Set<TEntity>();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task InsertAsync(TEntity entity)
        {
            _dbSet.Attach(entity);
            _appDbContext.Entry(entity).State = EntityState.Added;
            await SaveChangesAsync();
        }

        public async Task InsertInRangeAsync(List<TEntity> entities)
        {
            _appDbContext.AddRange(entities);
            await SaveChangesAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public bool Exists(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

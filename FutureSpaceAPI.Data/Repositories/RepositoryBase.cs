using FutureSpaceAPI.Domain.Entities;
using FutureSpaceAPI.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FutureSpaceAPI.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly ApplicationDbContext _appDbContext;

        public RepositoryBase(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = appDbContext.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> List()
        {
            return _dbSet;
        }

        public virtual void Create(TEntity entity)
        {
            _dbSet.Add(entity);
        }

    }
}

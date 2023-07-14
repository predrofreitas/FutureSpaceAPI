using FutureSpaceAPI.Domain.Entities;
using FutureSpaceAPI.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FutureSpaceAPI.Data.Repositories
{
    public class LauncherRepository : ILauncherRepository
    {
        private readonly IRepositoryBase<Launcher> _repositoryBase;

        public LauncherRepository(IRepositoryBase<Launcher> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task DeleteAsync(Launcher launcher)
        {
            await _repositoryBase.DeleteAsync(launcher);
        }

        public bool Exists(int id)
        {
            return _repositoryBase.Exists(id); ;
        }

        public async Task<Launcher> GetByIdAsync(int id)
        {
            return await _repositoryBase.GetByIdAsync(id);
        }

        public async Task InsertAsync(Launcher launcher)
        {
            await _repositoryBase.InsertAsync(launcher); 
        }
        public async Task<List<Launcher>> GetLaunchersPagedAsync(int page, int pageSize)
        {
            int skip = (page - 1) * pageSize;

            var launchers = await _dbContext.Launchers
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();

            return launchers;
        }

        public async Task SaveChangesAsync()
        {
            await _repositoryBase.SaveChangesAsync();
        }
    }
}

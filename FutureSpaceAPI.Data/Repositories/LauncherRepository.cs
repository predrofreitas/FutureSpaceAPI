using FutureSpaceAPI.Domain.Entities;
using FutureSpaceAPI.Domain.Interfaces.Repositories;

namespace FutureSpaceAPI.Data.Repositories
{
    public class LauncherRepository : ILauncherRepository
    {
        private readonly IRepositoryBase<Launcher> _repositoryBase;
        private readonly ApplicationDbContext _appDbContext;

        public LauncherRepository(IRepositoryBase<Launcher> repositoryBase, ApplicationDbContext appDbContext)
        {
            _repositoryBase = repositoryBase;
            _appDbContext = appDbContext;
        }

        public async Task DeleteAsync(Launcher launcher)
        {
            await _repositoryBase.DeleteAsync(launcher);
        }

        public bool Exists(Guid id)
        {
            return _repositoryBase.Exists(id); ;
        }

        public async Task<Launcher> GetByIdAsync(Guid id)
        {
            return await _repositoryBase.GetByIdAsync(id);
        }

        public async Task InsertAsync(Launcher launcher)
        {
            await _repositoryBase.InsertAsync(launcher); 
        }

        public async Task<IQueryable<Launcher>> GetAllLaunchersQueryable()
        {
            IQueryable<Launcher> launchersQuery = _appDbContext.Launchers;

            return launchersQuery;
        }

        public async Task SaveChangesAsync()
        {
            await _repositoryBase.SaveChangesAsync();
        }

        public async Task InsertInRangeAsync(List<Launcher> launchers)
        {
            await _repositoryBase.InsertInRangeAsync(launchers);
        }

        public async Task UpdateAsync(Launcher launcher)
        {
            await _repositoryBase.UpdateAsync(launcher);
        }
    }
}

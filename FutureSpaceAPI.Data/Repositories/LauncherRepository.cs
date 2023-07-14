using FutureSpaceAPI.Domain.Entities;
using FutureSpaceAPI.Domain.Interfaces.Repositories;

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

        public async Task SaveChangesAsync()
        {
            await _repositoryBase.SaveChangesAsync();
        }
    }
}

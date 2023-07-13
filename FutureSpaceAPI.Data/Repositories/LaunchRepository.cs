using FutureSpaceAPI.Domain.Entities;
using FutureSpaceAPI.Domain.Interfaces.Repositories;

namespace FutureSpaceAPI.Data.Repositories
{
    public class LaunchRepository : ILaunchRepository
    {
        private readonly IRepositoryBase<Launcher> _repositoryBase;

        public LaunchRepository(IRepositoryBase<Launcher> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        
    }
}

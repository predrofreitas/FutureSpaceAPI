using FutureSpaceAPI.Domain.Entities;

namespace FutureSpaceAPI.Domain.Interfaces.Services
{
    public interface ILauncherService
    {
        Task<Launcher> GetLauncher(int launchId);
    }
}

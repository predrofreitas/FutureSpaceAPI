using FutureSpaceAPI.Domain.Entities;

namespace FutureSpaceAPI.Domain.Interfaces.Services
{
    public interface ILauncherService
    {
        Task<List<Launcher>> GetLaunchersByPageAsync(int offset);
    }
}

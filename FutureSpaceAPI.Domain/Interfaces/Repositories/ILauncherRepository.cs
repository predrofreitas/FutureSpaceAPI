using FutureSpaceAPI.Domain.Entities;

namespace FutureSpaceAPI.Domain.Interfaces.Repositories
{
    public interface ILauncherRepository
    {
        Task InsertAsync(Launcher launcher);
        Task<Launcher> GetByIdAsync(int id);
        Task DeleteAsync(Launcher launcher);
        bool Exists(int id);
        Task<List<Launcher>> GetLaunchersPagedAsync(int page, int pageSize);
        Task SaveChangesAsync();
    }
}

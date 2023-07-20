using FutureSpaceAPI.Domain.Entities;

namespace FutureSpaceAPI.Domain.Interfaces.Repositories
{
    public interface ILauncherRepository
    {
        Task InsertAsync(Launcher launcher);
        Task InsertInRangeAsync(List<Launcher> launchers);
        Task<Launcher> GetByIdAsync(Guid id);
        Task DeleteAsync(Launcher launcher);
        bool Exists(Guid id);
        Task UpdateAsync(Launcher launcher);
        Task<IQueryable<Launcher>> GetAllLaunchersQueryable();
        Task SaveChangesAsync();
    }
}

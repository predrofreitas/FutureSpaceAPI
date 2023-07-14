using FutureSpaceAPI.Application.Commands;
using FutureSpaceAPI.Domain.Entities;
using FutureSpaceAPI.Domain.Interfaces.Repositories;
using MediatR;

namespace FutureSpaceAPI.Application.Handlers
{
    public class UpdateLauncherHandler : IRequestHandler<UpdateLauncherCommand, Launcher>
    {
        private readonly ILauncherRepository _launcherRepository;

        public UpdateLauncherHandler(ILauncherRepository launcherRepository)
        {
            _launcherRepository = launcherRepository;
        }

        public async Task<Launcher> Handle(UpdateLauncherCommand command, CancellationToken cancellationToken)
        {
            var existingLauncher = await _launcherRepository.GetByIdAsync(command.LauncherId);

            if (existingLauncher is null)
            {
                return default;
            }
            
            var updatedLauncher = command.Launcher;

            existingLauncher.Url = updatedLauncher.Url;
            existingLauncher.LaunchLibraryId = updatedLauncher.LaunchLibraryId;
            existingLauncher.Slug = updatedLauncher.Slug;
            existingLauncher.Name = updatedLauncher.Name;
            existingLauncher.Status = updatedLauncher.Status;
            existingLauncher.ImportDate = updatedLauncher.ImportDate;
            existingLauncher.Net = updatedLauncher.Net;
            existingLauncher.WindowEnd = updatedLauncher.WindowEnd;
            existingLauncher.WindowStart = updatedLauncher.WindowStart;
            existingLauncher.InHold = updatedLauncher.InHold;
            existingLauncher.TbdTime = updatedLauncher.TbdTime;
            existingLauncher.TbdDate = updatedLauncher.TbdDate;
            existingLauncher.Probability = updatedLauncher.Probability;
            existingLauncher.HoldReason = updatedLauncher.HoldReason;
            existingLauncher.FailReason = updatedLauncher.FailReason;
            existingLauncher.Hashtag = updatedLauncher.Hashtag;
            existingLauncher.LaunchServiceProvider = updatedLauncher.LaunchServiceProvider;
            existingLauncher.Rocket = updatedLauncher.Rocket;
            existingLauncher.Pad = updatedLauncher.Pad;
            existingLauncher.WebcastLive = updatedLauncher.WebcastLive;
            existingLauncher.Image = updatedLauncher.Image;

            await _launcherRepository.SaveChangesAsync();
            return existingLauncher;
        }
    }
}
    
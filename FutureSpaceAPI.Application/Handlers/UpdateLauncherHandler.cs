using FutureSpaceAPI.Application.Commands;
using FutureSpaceAPI.Application.Responses;
using FutureSpaceAPI.Domain.Interfaces.Repositories;
using MediatR;
using Newtonsoft.Json;

namespace FutureSpaceAPI.Application.Handlers
{
    public class UpdateLauncherHandler : IRequestHandler<UpdateLauncherCommand, LauncherResponse>
    {
        private readonly ILauncherRepository _launcherRepository;

        public UpdateLauncherHandler(ILauncherRepository launcherRepository)
        {
            _launcherRepository = launcherRepository;
        }

        public async Task<LauncherResponse> Handle(UpdateLauncherCommand command, CancellationToken cancellationToken)
        {
            var existingLauncher = await _launcherRepository.GetByIdAsync(command.LauncherId);

            if (existingLauncher is null)
            {
                return null;
            }

            existingLauncher.ImportDate = DateTime.Now;
            existingLauncher.LaunchJson = JsonConvert.SerializeObject(command.Launch);

            await _launcherRepository.UpdateAsync(existingLauncher);

            return new LauncherResponse(existingLauncher.ImportDate, existingLauncher.LaunchJson);
        }
    }
}
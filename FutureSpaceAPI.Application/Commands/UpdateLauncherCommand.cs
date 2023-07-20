using FutureSpaceAPI.Application.Responses;
using FutureSpaceAPI.Domain.Entities;
using MediatR;

namespace FutureSpaceAPI.Application.Commands
{
    public class UpdateLauncherCommand : IRequest<LauncherResponse>
    {
        public Guid LauncherId { get; private set; }
        public Launch Launch { get; private set; }

        public UpdateLauncherCommand(Guid launcherId, Launch launch)
        {
            LauncherId = launcherId;
            Launch = launch;
        }
    }
}
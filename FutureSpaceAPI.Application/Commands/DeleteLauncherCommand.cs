using FutureSpaceAPI.Domain.Entities;
using MediatR;

namespace FutureSpaceAPI.Application.Commands
{
    public class DeleteLauncherCommand : IRequest<bool>
    {
        public Guid LauncherId { get; private set; }

        public DeleteLauncherCommand(Guid launcherId)
        {
            LauncherId = launcherId;
        }
    }
}

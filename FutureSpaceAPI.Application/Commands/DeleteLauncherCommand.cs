using FutureSpaceAPI.Domain.Entities;
using MediatR;

namespace FutureSpaceAPI.Application.Commands
{
    public class DeleteLauncherCommand : IRequest<Launcher>
    {
        public int LauncherId { get; private set; }

        public DeleteLauncherCommand(int launcherId)
        {
            LauncherId = launcherId;
        }
    }
}

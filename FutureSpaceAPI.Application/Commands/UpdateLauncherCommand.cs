using FutureSpaceAPI.Domain.Entities;
using MediatR;

namespace FutureSpaceAPI.Application.Commands
{
    public class UpdateLauncherCommand : IRequest<Launcher>
    {
        public int LauncherId { get; private set; }
        public Launcher Launcher { get; private set; }

        public UpdateLauncherCommand(int launcherId, Launcher launcher)
        {
            LauncherId = launcherId;
            Launcher = launcher;
        }
    }
}

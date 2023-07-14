using FutureSpaceAPI.Application.Commands;
using FutureSpaceAPI.Domain.Entities;
using FutureSpaceAPI.Domain.Interfaces.Repositories;
using MediatR;

namespace FutureSpaceAPI.Application.Handlers
{
    public class DeleteLauncherHandler : IRequestHandler<DeleteLauncherCommand, Launcher>
    {
        private readonly ILauncherRepository _launcherRepository;

        public DeleteLauncherHandler(ILauncherRepository launcherRepository)
        {
            _launcherRepository = launcherRepository;
        }

        public async Task<Launcher> Handle(DeleteLauncherCommand request, CancellationToken cancellationToken)
        {
            var launcher = await _launcherRepository.GetByIdAsync(request.LauncherId);

            if (launcher is null)
            {
                return null;
            }

            await _launcherRepository.DeleteAsync(launcher);

            return launcher;
        }
    }
}

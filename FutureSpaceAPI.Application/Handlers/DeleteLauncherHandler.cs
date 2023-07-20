using FutureSpaceAPI.Application.Commands;
using FutureSpaceAPI.Domain.Interfaces.Repositories;
using MediatR;

namespace FutureSpaceAPI.Application.Handlers
{
    public class DeleteLauncherHandler : IRequestHandler<DeleteLauncherCommand, bool>
    {
        private readonly ILauncherRepository _launcherRepository;

        public DeleteLauncherHandler(ILauncherRepository launcherRepository)
        {
            _launcherRepository = launcherRepository;
        }

        public async Task<bool> Handle(DeleteLauncherCommand request, CancellationToken cancellationToken)
        {
            var launcher = await _launcherRepository.GetByIdAsync(request.LauncherId);

            if (launcher is null)
            {
                return false;
            }

            await _launcherRepository.DeleteAsync(launcher);

            return true;
        }
    }
}

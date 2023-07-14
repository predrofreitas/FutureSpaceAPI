using FutureSpaceAPI.Application.Queries;
using FutureSpaceAPI.Domain.Entities;
using FutureSpaceAPI.Domain.Interfaces.Repositories;
using MediatR;

namespace FutureSpaceAPI.Application.Handlers
{
    public class GetLauncherHandler : IRequestHandler<GetLauncherQuery, Launcher>
    {
        private readonly ILauncherRepository _launcherRepository;

        public GetLauncherHandler(ILauncherRepository launcherRepository)
        {
            _launcherRepository = launcherRepository;
        }

        public async Task<Launcher> Handle(GetLauncherQuery query, CancellationToken cancellationToken)
        {
            var launcher = await _launcherRepository.GetByIdAsync(query.LauncherId);

            if (launcher is null)
            {
                return null;
            }

            return launcher;
        }
    }
}

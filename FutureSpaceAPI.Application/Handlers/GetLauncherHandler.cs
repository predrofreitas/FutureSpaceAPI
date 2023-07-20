using FutureSpaceAPI.Application.Queries;
using FutureSpaceAPI.Application.Responses;
using FutureSpaceAPI.Domain.Interfaces.Repositories;
using MediatR;

namespace FutureSpaceAPI.Application.Handlers
{
    public class GetLauncherHandler : IRequestHandler<GetLauncherQuery, LauncherResponse>
    {
        private readonly ILauncherRepository _launcherRepository;

        public GetLauncherHandler(ILauncherRepository launcherRepository)
        {
            _launcherRepository = launcherRepository;
        }

        public async Task<LauncherResponse> Handle(GetLauncherQuery query, CancellationToken cancellationToken)
        {
            var launcher = await _launcherRepository.GetByIdAsync(query.LauncherId);

            if (launcher is null)
            {
                return null;
            }

            return new LauncherResponse(launcher.ImportDate, launcher.LaunchJson);
        }
    }
}
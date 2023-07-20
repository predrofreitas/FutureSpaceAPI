using FutureSpaceAPI.Application.Helpers;
using FutureSpaceAPI.Application.Queries;
using FutureSpaceAPI.Application.Responses;
using FutureSpaceAPI.Domain.Interfaces.Repositories;
using MediatR;

namespace FutureSpaceAPI.Application.Handlers
{
    public class GetAllLaunchersHandler : IRequestHandler<GetAllLaunchersQuery, PagedList<LauncherResponse>>
    {
        private readonly ILauncherRepository _launcherRepository;

        public GetAllLaunchersHandler(ILauncherRepository launcherRepository)
        {
            _launcherRepository = launcherRepository;
        }

        public async Task<PagedList<LauncherResponse>> Handle(GetAllLaunchersQuery query, CancellationToken cancellationToken)
        {
            var launchersQuery = await _launcherRepository.GetAllLaunchersQueryable();

            var launchersResponseQuery = launchersQuery.Select(e => new LauncherResponse(e.ImportDate, e.LaunchJson));

            var launchersPagedList = await PagedList<LauncherResponse>.CreateAsync(launchersResponseQuery, query.Page, query.PageSize);

            return launchersPagedList;
        }
    }
}

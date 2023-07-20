using FutureSpaceAPI.Application.Helpers;
using FutureSpaceAPI.Application.Responses;
using MediatR;

namespace FutureSpaceAPI.Application.Queries
{
    public class GetAllLaunchersQuery : IRequest<PagedList<LauncherResponse>>
    {
        public int Page { get; private set; }
        public int PageSize { get; private set; }

        public GetAllLaunchersQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}

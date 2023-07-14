using FutureSpaceAPI.Domain.Entities;
using MediatR;

namespace FutureSpaceAPI.Application.Queries
{
    public class GetLaunchersQuery : IRequest<List<Launcher>>
    {
        public int Page { get; private set; }
        public const int PageSize = 3;

        public GetLaunchersQuery(int page)
        {
            Page = page;
        }
    }
}

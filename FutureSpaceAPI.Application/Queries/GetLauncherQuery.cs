using FutureSpaceAPI.Application.Responses;
using FutureSpaceAPI.Domain.Entities;
using MediatR;

namespace FutureSpaceAPI.Application.Queries
{
    public class GetLauncherQuery : IRequest<LauncherResponse>
    {
        public Guid LauncherId { get; private set; }

        public GetLauncherQuery(Guid launcherId)
        {
            LauncherId = launcherId;
        }
    }
}

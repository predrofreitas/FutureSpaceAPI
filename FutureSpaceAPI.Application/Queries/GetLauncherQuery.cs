using FutureSpaceAPI.Domain.Entities;
using MediatR;

namespace FutureSpaceAPI.Application.Queries
{
    public class GetLauncherQuery : IRequest<Launcher>
    {
        public int LauncherId { get; private set; }

        public GetLauncherQuery(int launcherId)
        {
            LauncherId = launcherId;
        }
    }
}

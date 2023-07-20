using FutureSpaceAPI.Application.Commands;
using FutureSpaceAPI.Application.Handlers;
using FutureSpaceAPI.Application.Responses;
using FutureSpaceAPI.Domain.Entities;
using FutureSpaceAPI.Domain.Interfaces.Repositories;
using Moq;
using Xunit;

namespace FutureSpaceAPI.Tests.Handlers
{
    public class UpdateLauncherHandlerTests
    {
        private readonly Mock<ILauncherRepository> _repositoryMock;

        public UpdateLauncherHandlerTests()
        {
            _repositoryMock = new Mock<ILauncherRepository>();
        }

        [Fact]
        public async Task UpdateLauncherHandler_ExistentLauncher_ReturnsLauncherResponse()
        {
            var launchId = Guid.NewGuid();
            var launchJson = @"{""id"":""31bcb852-0c9f-4f1f-a201-a108c88e77f8"",""url"":""https://ll.thespacedevs.com/2.0.0/launch/31bcb852-0c9f-4f1f-a201-a108c88e77f8/"",""launchLibraryId"":null,""slug"":""project-pilot-nots-4"",""name"":""Project Pilot | NOTS 4"",""status"":{""id"":4,""name"":""Failure""},""net"":""1958-08-25T00:00:00Z"",""windowEnd"":""1958-08-25T00:00:00Z"",""windowStart"":""1958-08-25T00:00:00Z"",""inHold"":false,""tbdTime"":false,""tbdDate"":false,""probability"":null,""holdReason"":null,""failReason"":null,""hashtag"":null,""launchServiceProvider"":{""id"":166,""url"":""https://ll.thespacedevs.com/2.0.0/agencies/166/"",""name"":""US Navy"",""type"":""Government""},""rocket"":{""id"":3022,""configuration"":{""id"":344,""launchLibraryId"":null,""url"":""https://ll.thespacedevs.com/2.0.0/config/launcher/344/"",""name"":""Project Pilot"",""family"":"""",""fullName"":""Project Pilot"",""variant"":""""}},""pad"":{""id"":145,""url"":""https://ll.thespacedevs.com/2.0.0/pad/145/"",""agencyId"":null,""name"":""Naval Air Weapons Station China Lake"",""infoUrl"":null,""wikiUrl"":""https://en.wikipedia.org/wiki/Naval_Air_Weapons_Station_China_Lake"",""mapUrl"":""https://www.google.com/maps?q=35.6855556,-117.6941384"",""latitude"":""35.6855556"",""longitude"":""-117.6941384"",""location"":{""id"":144,""url"":""https://ll.thespacedevs.com/2.0.0/location/144/"",""name"":""Air launch to Suborbital flight"",""countryCode"":"""",""mapImage"":""https://spacelaunchnow-prod-east.nyc3.digitaloceanspaces.com/media/launch_images/location_144_20200803142439.jpg"",""totalLaunchCount"":80,""totalLandingCount"":0},""mapImage"":""https://spacelaunchnow-prod-east.nyc3.digitaloceanspaces.com/media/launch_images/pad_145_20200803143330.jpg"",""totalLaunchCount"":0},""webcastLive"":false,""image"":null}";

            var existingLauncher = new Launcher() { LaunchId = launchId, LaunchJson = launchJson };
            var updatedLaunch = new Launch() { Id = launchId };
            var command = new UpdateLauncherCommand(launchId, updatedLaunch);

            _repositoryMock.Setup(repo => repo.GetByIdAsync(launchId))
                          .ReturnsAsync(existingLauncher);

            var handler = new UpdateLauncherHandler(_repositoryMock.Object);

            LauncherResponse response = await handler.Handle(command, CancellationToken.None);

            _repositoryMock.Verify(repo => repo.GetByIdAsync(launchId), Times.Once);

            Assert.NotNull(response);
        }

        [Fact]
        public async Task UpdateLauncherHandler_NonExistentLauncher_ReturnsLauncherResponse()
        {
            var launcherId = Guid.NewGuid();
            var updatedLaunch = new Launch();
            var command = new UpdateLauncherCommand(launcherId, updatedLaunch);

            _repositoryMock.Setup(repo => repo.GetByIdAsync(launcherId))
                          .ReturnsAsync((Launcher)null);

            var handler = new UpdateLauncherHandler(_repositoryMock.Object);

            LauncherResponse response = await handler.Handle(command, CancellationToken.None);

            _repositoryMock.Verify(repo => repo.GetByIdAsync(launcherId), Times.Once);

            Assert.Null(response);
        }
    }
}
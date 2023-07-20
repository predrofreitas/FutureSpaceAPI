using FutureSpaceAPI.Application.Handlers;
using FutureSpaceAPI.Application.Queries;
using FutureSpaceAPI.Domain.Entities;
using FutureSpaceAPI.Domain.Interfaces.Repositories;
using Moq;
using Xunit;

namespace FutureSpaceAPI.Tests.Handlers
{
    public class GetLauncherHandlerTests
    {
        private readonly Mock<ILauncherRepository> _repositoryMock;

        public GetLauncherHandlerTests()
        {
            _repositoryMock = new Mock<ILauncherRepository>();
        }

        [Fact]
        public async Task GetLauncherHandler_WithValidId_ReturnsLauncherResponse()
        {
            var validLaunchId = Guid.NewGuid();
            var expectedImportDate = DateTime.UtcNow;
            var expectedLaunchJson = @"{""id"":""31bcb852-0c9f-4f1f-a201-a108c88e77f8"",""url"":""https://ll.thespacedevs.com/2.0.0/launch/31bcb852-0c9f-4f1f-a201-a108c88e77f8/"",""launchLibraryId"":null,""slug"":""project-pilot-nots-4"",""name"":""Project Pilot | NOTS 4"",""status"":{""id"":4,""name"":""Failure""},""net"":""1958-08-25T00:00:00Z"",""windowEnd"":""1958-08-25T00:00:00Z"",""windowStart"":""1958-08-25T00:00:00Z"",""inHold"":false,""tbdTime"":false,""tbdDate"":false,""probability"":null,""holdReason"":null,""failReason"":null,""hashtag"":null,""launchServiceProvider"":{""id"":166,""url"":""https://ll.thespacedevs.com/2.0.0/agencies/166/"",""name"":""US Navy"",""type"":""Government""},""rocket"":{""id"":3022,""configuration"":{""id"":344,""launchLibraryId"":null,""url"":""https://ll.thespacedevs.com/2.0.0/config/launcher/344/"",""name"":""Project Pilot"",""family"":"""",""fullName"":""Project Pilot"",""variant"":""""}},""pad"":{""id"":145,""url"":""https://ll.thespacedevs.com/2.0.0/pad/145/"",""agencyId"":null,""name"":""Naval Air Weapons Station China Lake"",""infoUrl"":null,""wikiUrl"":""https://en.wikipedia.org/wiki/Naval_Air_Weapons_Station_China_Lake"",""mapUrl"":""https://www.google.com/maps?q=35.6855556,-117.6941384"",""latitude"":""35.6855556"",""longitude"":""-117.6941384"",""location"":{""id"":144,""url"":""https://ll.thespacedevs.com/2.0.0/location/144/"",""name"":""Air launch to Suborbital flight"",""countryCode"":"""",""mapImage"":""https://spacelaunchnow-prod-east.nyc3.digitaloceanspaces.com/media/launch_images/location_144_20200803142439.jpg"",""totalLaunchCount"":80,""totalLandingCount"":0},""mapImage"":""https://spacelaunchnow-prod-east.nyc3.digitaloceanspaces.com/media/launch_images/pad_145_20200803143330.jpg"",""totalLaunchCount"":0},""webcastLive"":false,""image"":null}";

            _repositoryMock.Setup(repo => repo.GetByIdAsync(validLaunchId))
                .ReturnsAsync(new Launcher
                {
                    LaunchId = validLaunchId,
                    ImportDate = expectedImportDate,
                    LaunchJson = expectedLaunchJson
                });

            var handler = new GetLauncherHandler(_repositoryMock.Object);
            var query = new GetLauncherQuery(validLaunchId);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(expectedImportDate, result.ImportDate);
        }

        [Fact]
        public async Task GetLauncherHandler_WithInvalidId_ReturnsNull()
        {
            var invalidLauncherId = Guid.NewGuid();
            _repositoryMock.Setup(repo => repo.GetByIdAsync(invalidLauncherId))
                .ReturnsAsync((Launcher)null);

            var handler = new GetLauncherHandler(_repositoryMock.Object);
            var query = new GetLauncherQuery(invalidLauncherId);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.Null(result);
        }
    }

}

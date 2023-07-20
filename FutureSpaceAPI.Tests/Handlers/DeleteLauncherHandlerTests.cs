using FutureSpaceAPI.Application.Commands;
using FutureSpaceAPI.Application.Handlers;
using FutureSpaceAPI.Domain.Entities;
using FutureSpaceAPI.Domain.Interfaces.Repositories;
using Moq;
using Xunit;

namespace FutureSpaceAPI.Tests.Handlers
{
    public class DeleteLauncherHandlerTests
    {
        private readonly Mock<ILauncherRepository> _repositoryMock;

        public DeleteLauncherHandlerTests()
        {
            _repositoryMock = new Mock<ILauncherRepository>();
        }

        [Fact]
        public async Task DeleteLauncherHandler_ExistingLauncher_DeletesLauncherAndReturnsTrue()
        {
            var launchId = Guid.NewGuid();
            var existingLauncher = new Launcher();
            var command = new DeleteLauncherCommand(launchId);

            _repositoryMock.Setup(repo => repo.GetByIdAsync(launchId))
                          .ReturnsAsync(existingLauncher);

            var handler = new DeleteLauncherHandler(_repositoryMock.Object);

            bool result = await handler.Handle(command, CancellationToken.None);

            _repositoryMock.Verify(repo => repo.GetByIdAsync(launchId), Times.Once);
            _repositoryMock.Verify(repo => repo.DeleteAsync(existingLauncher), Times.Once);

            Assert.True(result);
        }

        [Fact]
        public async Task DeleteLauncherHandler_NonExistentLauncher_ReturnsFalse()
        {
            var launcherId = Guid.NewGuid();
            var command = new DeleteLauncherCommand(launcherId);

            _repositoryMock.Setup(repo => repo.GetByIdAsync(launcherId))
                          .ReturnsAsync((Launcher)null);

            var handler = new DeleteLauncherHandler(_repositoryMock.Object);

            bool result = await handler.Handle(command, CancellationToken.None);

            _repositoryMock.Verify(repo => repo.GetByIdAsync(launcherId), Times.Once);
            _repositoryMock.Verify(repo => repo.DeleteAsync(It.IsAny<Launcher>()), Times.Never);

            Assert.False(result);
        }
    }
}
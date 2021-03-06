using Camelot.Services.Abstractions;
using Camelot.ViewModels.Implementations.MainWindow;
using Moq;
using Xunit;

namespace Camelot.ViewModels.Tests
{
    public class TopOperationsViewModelTests
    {
        private const string Directory = "Directory";

        [Fact]
        public void TestOpenTerminalCommand()
        {
            var terminalServiceMock = new Mock<ITerminalService>();
            terminalServiceMock
                .Setup(m => m.Open(Directory))
                .Verifiable();
            var directoryServiceMock = new Mock<IDirectoryService>();
            directoryServiceMock
                .SetupGet(m => m.SelectedDirectory)
                .Returns(Directory);

            var viewModel = new TopOperationsViewModel(terminalServiceMock.Object,
                directoryServiceMock.Object);

            Assert.True(viewModel.OpenTerminalCommand.CanExecute(null));
            viewModel.OpenTerminalCommand.Execute(null);

            terminalServiceMock.Verify(m => m.Open(Directory), Times.Once());
        }
    }
}
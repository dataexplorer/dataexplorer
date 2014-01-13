using DataExplorer.Application;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Projects;
using DataExplorer.Application.Projects.Commands;
using DataExplorer.Application.Web;
using DataExplorer.Application.Web.Commands;
using DataExplorer.Presentation.Panes.Navigation.StartMenu;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Navigation.StartMenu
{
    [TestFixture]
    public class StartMenuViewModelTests
    {
        private StartMenuViewModel _viewModel;
        private Mock<ICommandBus> _mockCommandBus;
        private Mock<IDialogService> _mockDialogService;
        
        [SetUp]
        public void SetUp()
        {
            _mockCommandBus = new Mock<ICommandBus>();
            _mockDialogService = new Mock<IDialogService>();

            _viewModel = new StartMenuViewModel(
                _mockCommandBus.Object,
                _mockDialogService.Object);
        }

        [Test]
        public void TestOpenShouldOpenProject()
        {
            _viewModel.OpenCommand.Execute(null);
            _mockCommandBus.Verify(p => p.Execute(It.IsAny<OpenProjectCommand>()), 
                Times.Once());
        }

        [Test]
        public void TestImportShouldImport()
        {
            _viewModel.ImportCommand.Execute(null);
            _mockDialogService.Verify(p => p.ShowImportDialog(), Times.Once());
        }

        [Test]
        public void TestDownloadShouldDownload()
        {
            _viewModel.DownloadDataCommand.Execute(null);
            _mockCommandBus.Verify(p => p.Execute(It.IsAny<OpenDownloadDataPageCommand>()),
    Times.Once());
        }
    }
}

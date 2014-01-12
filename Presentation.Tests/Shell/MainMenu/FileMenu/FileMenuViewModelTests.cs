using DataExplorer.Application;
using DataExplorer.Application.Application.Commands;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Projects;
using DataExplorer.Presentation.Shell.MainMenu.FileMenu;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Shell.MainMenu.FileMenu
{
    [TestFixture]
    public class FileMenuViewModelTests
    {
        private FileMenuViewModel _viewModel;
        private Mock<ICommandBus> _mockCommandBus;
        private Mock<IProjectService> _mockProjectService;
        private Mock<IDialogService> _mockDialogService;

        [SetUp]
        public void SetUp()
        {
            _mockCommandBus = new Mock<ICommandBus>();
            _mockProjectService = new Mock<IProjectService>();
            _mockDialogService = new Mock<IDialogService>();
            _viewModel = new FileMenuViewModel(
                _mockCommandBus.Object, 
                _mockProjectService.Object, 
                _mockDialogService.Object);
        }

        [Test]
        public void TestOpenCommandShouldOpenProject()
        {
            // TODO: This will eventually need to show the Open Project dialog box
            _viewModel.OpenCommand.Execute(null);
            _mockProjectService.Verify(p => p.OpenProject(), Times.Once());
        }

        [Test]
        public void TestSaveCommandShouldSaveProject()
        {
            _viewModel.SaveCommand.Execute(null);
            _mockProjectService.Verify(p => p.SaveProject(), Times.Once());
        }

        [Test]
        public void TestCloseCommandShouldCloseProject()
        {
            _viewModel.CloseCommand.Execute(null);
            _mockProjectService.Verify(p => p.CloseProject(), Times.Once());
        }

        [Test]
        public void TestImportCommandShouldOpenImportDialog()
        {
            _viewModel.ImportCommand.Execute(null);
            _mockDialogService.Verify(p => p.ShowImportDialog(), Times.Once());
        }

        [Test]
        public void TestExitCommandShouldExit()
        {
            _viewModel.ExitCommand.Execute(null);
            _mockCommandBus.Verify(p => p.Execute(It.IsAny<ExitCommand>()), Times.Once());
        }
    }
}

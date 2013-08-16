using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application;
using DataExplorer.Application.Application;
using DataExplorer.Application.Projects;
using DataExplorer.Presentation.Shell.MainMenu.FileMenu;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Shell.MainMenu.FileMenu
{
    [TestFixture]
    public class FileMenuViewModelTests
    {
        private FileMenuViewModel _viewModel;
        private Mock<IApplicationService> _mockFileService;
        private Mock<IProjectService> _mockProjectService;

        [SetUp]
        public void SetUp()
        {
            _mockFileService = new Mock<IApplicationService>();
            _mockProjectService = new Mock<IProjectService>();
            _viewModel = new FileMenuViewModel(
                _mockFileService.Object, 
                _mockProjectService.Object);
        }

        [Test]
        public void TestExitCommandShouldExit()
        {
            _viewModel.ExitCommand.Execute(null);
            _mockFileService.Verify(p => p.Exit(), Times.Once());
        }

        [Test]
        public void TestOpenCommandShouldOpenProject()
        {
            // TODO: This will eventually need to show the Open Project dialog box
            _viewModel.OpenCommand.Execute(null);
            _mockProjectService.Verify(p => p.OpenProject(), Times.Once());
        }

        [Test]
        public void TestCloseCommandShouldCloseProject()
        {
            _viewModel.CloseCommand.Execute(null);
            _mockProjectService.Verify(p => p.CloseProject(), Times.Once());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Projects;
using DataExplorer.Application.Web;
using DataExplorer.Presentation.Dialogs;
using DataExplorer.Presentation.Panes.Navigation.StartMenu;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Panes.Navigation.StartMenu
{
    [TestFixture]
    public class StartMenuViewModelTests
    {
        private StartMenuViewModel _viewModel;
        private Mock<IProjectService> _mockProjectService;
        private Mock<IDialogService> _mockDialogService;
        private Mock<IWebService> _mockWebService;

        [SetUp]
        public void SetUp()
        {
            _mockProjectService = new Mock<IProjectService>();
            _mockDialogService = new Mock<IDialogService>();
            _mockWebService = new Mock<IWebService>();
            _viewModel = new StartMenuViewModel(
                _mockProjectService.Object,
                _mockDialogService.Object,
                _mockWebService.Object);
        }

        [Test]
        public void TestOpenShouldOpenProject()
        {
            _viewModel.OpenCommand.Execute(null);
            _mockProjectService.Verify(p => p.OpenProject(), Times.Once());
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
            _mockWebService.Verify(p => p.LaunchDownloadDataPage());
        }
    }
}

using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Layouts.General.Commands;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Application.Views.ScatterPlots.Commands;
using DataExplorer.Presentation.Shell.MainMenu.ViewMenu;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Shell.MainMenu.ViewMenu
{
    [TestFixture]
    public class ViewMenuViewModelTests
    {
        private ViewMenuViewModel _viewModel;
        private Mock<ICommandBus> _mockCommandBus;
        
        [SetUp]
        public void SetUp()
        {
            _mockCommandBus = new Mock<ICommandBus>();

            _viewModel = new ViewMenuViewModel(_mockCommandBus.Object);
        }

        [Test]
        public void TestZoomToFullExtentShouldZoomToFullExtent()
        {
            _viewModel.ZoomToFullExtentCommand.Execute(null);
            _mockCommandBus.Verify(p => p.Execute(It.IsAny<ZoomToFullExtentCommand>()),
                Times.Once());
        }

        [Test]
        public void TestClearLayoutShouldClearLayout()
        {
            _viewModel.ClearLayoutCommand.Execute(null);
            _mockCommandBus.Verify(p => p.Execute(It.IsAny<ClearLayoutCommand>()),
                Times.Once());
        }
    }
}

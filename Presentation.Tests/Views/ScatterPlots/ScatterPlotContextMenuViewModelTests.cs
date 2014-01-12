using DataExplorer.Application.Clipboard;
using DataExplorer.Application.Rows;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Presentation.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Views.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotContextMenuViewModelTests
    {
        private ScatterPlotContextMenuViewModel _viewModel;
        private Mock<IClipboardService> _mockClipboardService;
        private Mock<IScatterPlotService> _mockScatterPlotService;
        private Mock<IScatterPlotLayoutService> _mockLayoutService;

        [SetUp]
        public void SetUp()
        {
            _mockClipboardService = new Mock<IClipboardService>();
            _mockScatterPlotService = new Mock<IScatterPlotService>();
            _mockLayoutService = new Mock<IScatterPlotLayoutService>();

            _viewModel = new ScatterPlotContextMenuViewModel(
                _mockClipboardService.Object,
                _mockScatterPlotService.Object,
                _mockLayoutService.Object);
        }

        [Test]
        public void TestExecuteCopyCommandShouldCopyData()
        {
            _viewModel.CopyCommand.Execute(null);
            _mockClipboardService.Verify(p => p.Copy());
        }

        [Test]
        public void TestExecuteCopyImageCommandShouldCopyImage()
        {
            _viewModel.CopyImageCommand.Execute(null);
            _mockClipboardService.Verify(p => p.CopyImage());
        }

        [Test]
        public void TestExecuteZoomToFullExtentShouldZoomToFullExtent()
        {
            _viewModel.ZoomToFullExtentCommand.Execute(null);
            _mockScatterPlotService.Verify(p => p.ZoomToFullExtent(), Times.Once());
        }

        [Test]
        public void TestExecuteClearLayoutShouldClearLayout()
        {
            _viewModel.ClearLayoutCommand.Execute(null);
            _mockLayoutService.Verify(p => p.ClearLayout(), Times.Once());
        }

        [Test]
        public void TestHandleSelectedRowsChangedShouldRaiseCanCopyChangedEvent()
        {
            var wasRaised = false;
            _viewModel.CopyCommand.CanExecuteChanged += (s, e) => wasRaised = true;
            _viewModel.Handle(new SelectedRowsChangedEvent());
            Assert.That(wasRaised, Is.True);
        }
    }
}

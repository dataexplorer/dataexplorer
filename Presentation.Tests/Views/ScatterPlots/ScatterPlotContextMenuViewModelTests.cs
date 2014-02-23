using DataExplorer.Application.Clipboard.Commands;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Layouts.General.Commands;
using DataExplorer.Application.Rows;
using DataExplorer.Application.Rows.Events;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Application.Views.ScatterPlots.Commands;
using DataExplorer.Presentation.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Views.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotContextMenuViewModelTests
    {
        private ScatterPlotContextMenuViewModel _viewModel;
        private Mock<IMessageBus> _mockMessageBus;
        
        [SetUp]
        public void SetUp()
        {
            _mockMessageBus = new Mock<IMessageBus>();

            _viewModel = new ScatterPlotContextMenuViewModel(_mockMessageBus.Object);
        }

        [Test]
        public void TestExecuteCopyCommandShouldCopyData()
        {
            _viewModel.CopyCommand.Execute(null);
            _mockMessageBus.Verify(p => p.Execute(It.IsAny<CopyDataToClipboardCommand>()));
        }

        [Test]
        public void TestExecuteCopyImageCommandShouldCopyImage()
        {
            _viewModel.CopyImageCommand.Execute(null);
            _mockMessageBus.Verify(p => p.Execute(It.IsAny<CopyImageToClipboardCommand>()));
        }

        [Test]
        public void TestExecuteZoomToFullExtentShouldZoomToFullExtent()
        {
            _viewModel.ZoomToFullExtentCommand.Execute(null);
            _mockMessageBus.Verify(p => p.Execute(It.IsAny<ZoomToFullExtentCommand>()));
        }

        [Test]
        public void TestExecuteClearLayoutShouldClearLayout()
        {
            _viewModel.ClearLayoutCommand.Execute(null);
            _mockMessageBus.Verify(p => p.Execute(It.IsAny<ClearLayoutCommand>()));
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

using System.Windows;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Application.Views.ScatterPlots.Commands;
using DataExplorer.Application.Views.ScatterPlots.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.Commands;
using DataExplorer.Presentation.Views.ScatterPlots.Scalers;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Views.ScatterPlots.Commands
{
    [TestFixture]
    public class ResizeScatterPlotViewExtentCommandTests
    {
        private ResizeScatterPlotViewExtentCommand _command;
        private Mock<IMessageBus> _mockService;
        private Mock<IViewResizer> _mockResizer;
        private Size _controlSize;
        private Rect _viewExtent;
        private Rect _newViewExtent;

        [SetUp]
        public void SetUp()
        {
            _controlSize = new Size();
            _viewExtent = new Rect();
            _newViewExtent = new Rect();

            _mockService = new Mock<IMessageBus>();
            _mockService.Setup(p => p.Execute(It.IsAny<GetViewExtentQuery>()))
                .Returns(_viewExtent);

            _mockResizer = new Mock<IViewResizer>();
            _mockResizer.Setup(p => p.ResizeView(_controlSize, _viewExtent))
                .Returns(_newViewExtent);

            _command = new ResizeScatterPlotViewExtentCommand(
                _mockService.Object,
                _mockResizer.Object);
        }

        [Test]
        public void TestExecuteShouldResizeViewExtent()
        {
            _command.Execute(_controlSize);
            _mockService.Verify(p => p.Execute(It.Is<SetViewExtentCommand>(q => q.ViewExtent == _newViewExtent)),
                Times.Once());
        }

    }
}

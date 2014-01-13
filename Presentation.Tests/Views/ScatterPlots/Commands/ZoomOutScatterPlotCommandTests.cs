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
    public class ZoomOutScatterPlotCommandTests
    {
        private ZoomOutScatterPlotCommand _command;
        private Mock<IMessageBus> _mockService;
        private Mock<IPointScaler> _mockScaler;
        private Rect _viewExtent;
        private Size _controlSize;
        private Point _targetPoint;
        private Point _sourcePoint;

        [SetUp]
        public void SetUp()
        {
            _viewExtent = new Rect();
            _controlSize = new Size();
            _sourcePoint = new Point();
            _targetPoint = new Point();

            _mockService = new Mock<IMessageBus>();
            _mockService.Setup(p => p.Execute(It.IsAny<GetViewExtentQuery>()))
                .Returns(_viewExtent);

            _mockScaler = new Mock<IPointScaler>();
            _mockScaler.Setup(p => p.ScalePoint(_sourcePoint, _controlSize, _viewExtent))
                .Returns(_targetPoint);

            _command = new ZoomOutScatterPlotCommand(
                _mockService.Object,
                _mockScaler.Object);
        }

        [Test]
        public void TestExecuteShouldZoomOut()
        {
            _command.Execute(_sourcePoint, _controlSize);
            _mockService.Verify(p => p.Execute(It.Is<ZoomOutCommand>(q => q.Center == _sourcePoint)),
                Times.Once());
        }
    }
}

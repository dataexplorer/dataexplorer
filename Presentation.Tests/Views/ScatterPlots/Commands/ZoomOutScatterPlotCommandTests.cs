using System.Windows;
using DataExplorer.Application.Views.ScatterPlots;
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
        private Mock<IScatterPlotService> _mockService;
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

            _mockService = new Mock<IScatterPlotService>();
            _mockService.Setup(p => p.GetViewExtent()).Returns(_viewExtent);

            _mockScaler = new Mock<IPointScaler>();
            _mockScaler.Setup(p => p.ScalePoint(_sourcePoint, _controlSize, _viewExtent)).Returns(_targetPoint);

            _command = new ZoomOutScatterPlotCommand(
                _mockService.Object,
                _mockScaler.Object);
        }

        [Test]
        public void TestExecuteShouldZoomOut()
        {
            _command.Execute(_sourcePoint, _controlSize);
            _mockService.Verify(p => p.ZoomOut(_sourcePoint), Times.Once());
        }
    }
}

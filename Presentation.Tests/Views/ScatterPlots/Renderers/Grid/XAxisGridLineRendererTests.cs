using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Presentation.Views.ScatterPlots.Grid.Lines.Renderers;
using DataExplorer.Presentation.Views.ScatterPlots.Scalers;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Views.ScatterPlots.Grid.Lines.Renderers
{
    public class XAxisGridLineRendererTests
    {
        private XAxisGridLineRenderer _renderer;
        private Mock<IValueScaler> _mockScaler;
        private Rect _viewExtent;
        private Size _controlSize;
        private List<AxisGridLine> _axisLines;
        private AxisGridLine _axisGridLine;

        [SetUp]
        public void SetUp()
        {
            _viewExtent = new Rect(0, 0, 10, 10);
            _controlSize = new Size(10, 20);

            _axisGridLine = new AxisGridLine() { Position = 5d };
            _axisLines = new List<AxisGridLine> { _axisGridLine };

            _mockScaler = new Mock<IValueScaler>();
            _mockScaler.Setup(p => p.Scale(5d, 0, 10, 0, 10)).Returns(5);

            _renderer = new XAxisGridLineRenderer(
                _mockScaler.Object);
        }

        [Test]
        public void TestRenderShouldReturnCanvasLine()
        {
            var results = _renderer.Render(_axisLines, _viewExtent, _controlSize);
            var canvasLine = results.Single();
            Assert.That(canvasLine.X1, Is.EqualTo(5d));
            Assert.That(canvasLine.Y1, Is.EqualTo(0d));
            Assert.That(canvasLine.X2, Is.EqualTo(5d));
            Assert.That(canvasLine.Y2, Is.EqualTo(-25d));
        }
    }
}

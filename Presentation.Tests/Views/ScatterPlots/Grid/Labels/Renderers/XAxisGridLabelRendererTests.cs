using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Presentation.Views.ScatterPlots.Grid.Labels.Renderers;
using DataExplorer.Presentation.Views.ScatterPlots.Scalers;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots.Grid.Labels.Renderers
{
    [TestFixture]
    public class XAxisGridLineLabelRendererTests
    {
        private XAxisGridLabelRenderer _renderer;
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

            _axisGridLine = new AxisGridLine() { Position = 5d, LabelName = "Test" };
            _axisLines = new List<AxisGridLine> { _axisGridLine };

            _mockScaler = new Mock<IValueScaler>();
            _mockScaler.Setup(p => p.Scale(5d, 0, 10, 0, 10)).Returns(5);

            _renderer = new XAxisGridLabelRenderer(
                _mockScaler.Object);
        }

        [Test]
        public void TestRenderShouldReturnCanvasLine()
        {
            var results = _renderer.Render(_axisLines, _viewExtent, _controlSize);
            var canvasLabel = results.Single();
            Assert.That(canvasLabel.Text, Is.EqualTo("Test"));
            Assert.That(canvasLabel.X, Is.EqualTo(5d));
            Assert.That(canvasLabel.Y, Is.EqualTo(5d));
        }
    }
}

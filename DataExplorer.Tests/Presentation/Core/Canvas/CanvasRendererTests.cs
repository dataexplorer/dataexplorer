using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using DataExplorer.Presentation.Core.Canvas;
using DataExplorer.Presentation.Core.Canvas.Renderers;
using DataExplorer.Presentation.Core.Geometry;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Core.Canvas
{
    [TestFixture]
    public class CanvasRendererTests
    {
        private CanvasRenderer _canvasRenderer;
        private Mock<ICanvasBackgroundRenderer> _mockBackgroundRenderer;
        private Mock<ICanvasPlotRenderer> _mockPlotRenderer;
        private List<Visual> _visuals;
        private FakeVisual _visual;
        private List<Circle> _plots;
        private Circle _plot;

        [SetUp]
        public void SetUp()
        {
            _plot = new Circle();
            _plots = new List<Circle> { _plot };
            _visual = new FakeVisual();
            _visuals = new List<Visual> { _visual };
            _mockBackgroundRenderer = new Mock<ICanvasBackgroundRenderer>();
            _mockPlotRenderer = new Mock<ICanvasPlotRenderer>();
            _canvasRenderer = new CanvasRenderer(
                _mockBackgroundRenderer.Object,
                _mockPlotRenderer.Object);
        }

        [Test]
        public void TestDrawBackgroundShouldDrawBackground()
        {
            _visual = new FakeVisual();
            _mockBackgroundRenderer.Setup(p => p.DrawBackground(1d, 2d)).Returns(_visual);
            var result = _canvasRenderer.DrawBackground(1d, 2d);
            Assert.That(result, Is.EqualTo(_visual));
        }

        [Test]
        public void TestDrawPlotsShouldDrawPlots()
        {
            _mockPlotRenderer.Setup(p => p.DrawPlots(_plots)).Returns(_visuals);
            var results = _canvasRenderer.DrawPlots(_plots);
            Assert.That(results, Is.EqualTo(_visuals));
        }
    }
}

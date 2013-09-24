using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using DataExplorer.Presentation.Core.Canvas.Renderers;
using DataExplorer.Presentation.Core.Geometry;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Core.Canvas.Renderers
{
    [TestFixture]
    public class CanvasPlotRendererTests
    {
        private CanvasPlotRenderer _renderer;
        private Mock<ICanvasCirclePlotRenderer> _mockCircleRenderer;
        
        [SetUp]
        public void SetUp()
        {
            _mockCircleRenderer = new Mock<ICanvasCirclePlotRenderer>();
            _renderer = new CanvasPlotRenderer(_mockCircleRenderer.Object);
        }

        [Test]
        public void TestDrawPlotShouldDrawCircle()
        {
            var plot = new Circle();
            var plots = new List<Circle> { plot };
            var visual = new FakeVisual();
            var visuals = new List<Visual> { visual };
            _mockCircleRenderer.Setup(p => p.DrawCircle(plot, It.IsAny<SolidColorBrush>(), It.IsAny<Pen>())).Returns(visual);
            var result = _renderer.DrawPlots(plots);
            Assert.That(result, Is.EqualTo(visuals));
        }
        
    }
}

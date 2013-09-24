using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using DataExplorer.Presentation.Core.Canvas.Renderers;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Core.Canvas.Renderers
{
    [TestFixture]
    public class CanvasBackgroundRendererTests
    {
        private CanvasBackgroundRenderer _renderer;

        [SetUp]
        public void SetUp()
        {
            _renderer = new CanvasBackgroundRenderer();
        }

        [Test]
        public void TestDrawShouldDrawBackground()
        {
            var result = _renderer.DrawBackground(100d, 200d);
            var visual = (DrawingVisual) result;
            var drawing = (GeometryDrawing) visual.Drawing.Children[0];
            var fill = (SolidColorBrush) drawing.Brush;
            Assert.That(drawing.Geometry is RectangleGeometry);
            Assert.That(drawing.Geometry.Bounds, Is.EqualTo(new Rect(0, 0, 100, 200)));
            Assert.That(fill.Color, Is.EqualTo(Colors.White));
        }
    }
}

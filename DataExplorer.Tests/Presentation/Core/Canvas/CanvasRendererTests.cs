using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using DataExplorer.Presentation.Core.Canvas;
using DataExplorer.Presentation.Core.Geometry;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Core.Canvas
{
    [TestFixture]
    public class CanvasRendererTests
    {
        private CanvasRenderer _renderer;

        [SetUp]
        public void SetUp()
        {
            _renderer = new CanvasRenderer();
        }

        [Test]
        public void TestDrawVisualsWithACircleReturnsACircle()
        {
            var circle = new Circle() { X = 0, Y = 0, Radius = 8};
            var circles = new List<Circle> { circle };
            var results = _renderer.DrawVisuals(circles);
            var visual = (DrawingVisual) results.Single();
            var drawing = (GeometryDrawing) visual.Drawing.Children[0];
            var outline = (SolidColorBrush) drawing.Pen.Brush;
            var fill = (SolidColorBrush) drawing.Brush;
            Assert.That(drawing.Geometry, Is.TypeOf<EllipseGeometry>());
            Assert.That(drawing.Geometry.Bounds, Is.EqualTo(new Rect(-8, -8, 16, 16)));
            Assert.That(outline.Color, Is.EqualTo(Colors.Black));
            Assert.That(fill.Color, Is.EqualTo(Colors.LightBlue));
        }
    }
}

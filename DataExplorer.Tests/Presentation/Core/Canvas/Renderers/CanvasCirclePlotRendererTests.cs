using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using DataExplorer.Presentation.Core.Canvas.Renderers;
using DataExplorer.Presentation.Core.Geometry;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Core.Canvas.Renderers
{
    [TestFixture]
    public class CanvasCirclePlotRendererTests
    {
        private CanvasCirclePlotRenderer _renderer;

        [SetUp]
        public void SetUp()
        {
            _renderer = new CanvasCirclePlotRenderer();
        }

        [Test]
        public void TestDrawVisualsWithACircleReturnsACircle()
        {
            var circle = new Circle() { X = 0, Y = 0, Radius = 8 };
            var brush = new SolidColorBrush(Colors.LightBlue);
            var pen = new Pen(Brushes.Black, 1);
            var result = _renderer.DrawCircle(circle, brush, pen);
            var visual = (DrawingVisual) result;
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

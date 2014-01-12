using System.Windows.Media;
using DataExplorer.Presentation.Core.Canvas.Items;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Core.Canvas.Items
{
    [TestFixture]
    public class CanvasLineTests
    {
        private CanvasLine _line;
       
        [SetUp]
        public void SetUp()
        {
            _line = new CanvasLine();
            _line.X1 = 0;
            _line.Y1 = 0;
            _line.X2 = 10;
            _line.Y2 = 10;
        }

        [Test]
        public void TestDrawShouldReturnDrawingVisual()
        {
            var result = _line.Draw();
            var visual = (DrawingVisual) result;
            var drawing = (GeometryDrawing) visual.Drawing.Children[0];
            Assert.That(drawing.Geometry, Is.TypeOf<LineGeometry>());
        }

        [Test]
        public void TestDrawShouldReturnDrawingWithinBounds()
        {
            var result = _line.Draw();
            var visual = (DrawingVisual) result;
            var drawing = (GeometryDrawing) visual.Drawing.Children[0];
            var geometry = (LineGeometry) drawing.Geometry;
            var bounds = geometry.Bounds;
            Assert.That(bounds.Top, Is.EqualTo(0));
            Assert.That(bounds.Left, Is.EqualTo(0));
            Assert.That(bounds.Height, Is.EqualTo(10));
            Assert.That(bounds.Width, Is.EqualTo(10));
        }
    }
}

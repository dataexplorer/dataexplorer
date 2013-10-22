using System.Windows;
using System.Windows.Media;
using DataExplorer.Presentation.Core.Canvas.Items;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Core.Canvas.Items
{
    [TestFixture]
    public class CanvasBackgroundTests
    {
        private CanvasBackground _background;

        [SetUp]
        public void SetUp()
        {
            _background = new CanvasBackground();
            _background.Width = 100d;
            _background.Height = 200d;
        }

        [Test]
        public void TestDrawShouldDrawBackground()
        {
            var result = _background.Draw();
            var visual = (DrawingVisual) result;
            var drawing = (GeometryDrawing) visual.Drawing.Children[0];
            var fill = (SolidColorBrush) drawing.Brush;
            Assert.That(drawing.Geometry is RectangleGeometry);
            Assert.That(drawing.Geometry.Bounds, Is.EqualTo(new Rect(0, 0, 100d, 200d)));
            Assert.That(fill.Color, Is.EqualTo(Colors.White));
        }
    }
}

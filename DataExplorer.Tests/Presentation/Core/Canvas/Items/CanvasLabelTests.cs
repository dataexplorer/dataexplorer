using System.Windows.Media;
using DataExplorer.Presentation.Core.Canvas.Items;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Core.Canvas.Items
{
    [TestFixture]
    public class CanvasLabelTests
    {
        private CanvasLabel _label;

        [SetUp]
        public void SetUp()
        {
            _label = new CanvasLabel();
            _label.X = 0;
            _label.Y = 0;
            _label.Text = "Test";
        }

        [Test]
        public void TestDrawLabelShouldDrawGlyphRunDrawing()
        {
            var result = _label.Draw();
            var visual = (DrawingVisual) result;
            var drawing = (DrawingGroup) visual.Drawing.Children[0];
            var glyphRun = (GlyphRunDrawing) drawing.Children[0];
            Assert.That(glyphRun, Is.TypeOf<GlyphRunDrawing>());
        }

        [Test]
        public void TestDrawLabelShouldDrawText()
        {
            var result = _label.Draw();
            var visual = (DrawingVisual) result;
            var drawing = (DrawingGroup) visual.Drawing.Children[0];
            var glyphRun = (GlyphRunDrawing) drawing.Children[0];
            var characters = glyphRun.GlyphRun.Characters;
            Assert.That(characters[0], Is.EqualTo('T'));
            Assert.That(characters[1], Is.EqualTo('e'));
            Assert.That(characters[2], Is.EqualTo('s'));
            Assert.That(characters[3], Is.EqualTo('t'));
        }

        [Test]
        public void TestDrawLabelShouldDrawTextInColor()
        {
            var result = _label.Draw();
            var visual = (DrawingVisual) result;
            var drawing = (DrawingGroup) visual.Drawing.Children[0];
            var glyphRun = (GlyphRunDrawing) drawing.Children[0];
            var brush = (SolidColorBrush )glyphRun.ForegroundBrush;
            Assert.That(brush.Color, Is.EqualTo(Colors.Black));
        }
    }
}

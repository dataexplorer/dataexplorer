﻿using System.Windows;
using System.Windows.Media;
using DataExplorer.Presentation.Core.Canvas.Items;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Core.Canvas.Items
{
    [TestFixture]
    public class CanvasCircleTests
    {
        private CanvasCircle _circle;
        private SolidColorBrush _brush;
        private Pen _pen;

        [SetUp]
        public void SetUp()
        {
            _circle = new CanvasCircle()
            {
                X = 0,
                Y = 0,
                Radius = 8,
                Color = Colors.LightBlue
            };

            _brush = new SolidColorBrush(Colors.LightBlue);
            _pen = new Pen(Brushes.Black, 1);
        }

        [Test]
        public void TestDrawCircleShouldDrawEllipseGeometry()
        {
            var result = _circle.Draw();
            var visual = (DrawingVisual) result;
            var drawing = (GeometryDrawing) visual.Drawing.Children[0];
            Assert.That(drawing.Geometry, Is.TypeOf<EllipseGeometry>());
        }

        [Test]
        public void TestDrawCircleShouldDrawWithinBounds()
        {
            var result = _circle.Draw();
            var visual = (DrawingVisual) result;
            var drawing = (GeometryDrawing) visual.Drawing.Children[0];
            Assert.That(drawing.Geometry.Bounds, Is.EqualTo(new Rect(-8, -8, 16, 16)));
        }

        [Test]
        public void TestDrawCircleShouldDrawBlackOutline()
        {
            var result = _circle.Draw();
            AssertItemOutlineColor(result, Colors.Black);
        }

        [Test]
        public void TestDrawCircleShouldDrawBlueOutlineIfSelected()
        {
            _circle.IsSelected = true;
            var result = _circle.Draw();
            AssertItemOutlineColor(result, Colors.Blue);
        }

        private static void AssertItemOutlineColor(VisualItem item, Color color)
        {
            var visual = (DrawingVisual) item;
            var drawing = (GeometryDrawing) visual.Drawing.Children[0];
            var outline = (SolidColorBrush) drawing.Pen.Brush;
            Assert.That(outline.Color, Is.EqualTo(color));
        }

        [Test]
        public void TestDrawCircleShouldDrawLightBlueFill()
        {
            var result = _circle.Draw();
            var visual = (DrawingVisual) result;
            var drawing = (GeometryDrawing) visual.Drawing.Children[0];
            var fill = (SolidColorBrush) drawing.Brush;
            Assert.That(fill.Color, Is.EqualTo(Colors.LightBlue));
        }
    }
}

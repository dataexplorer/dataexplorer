using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DataExplorer.Presentation.Core.Canvas.Factories;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Core.Canvas.Factories
{
    [TestFixture]
    public class CanvasItemFactoryTests
    {
        private CanvasItemFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new CanvasItemFactory();
        }

        [Test]
        public void TestCreateCircleShouldCreateCircle()
        {
            var extent = new Rect(1, 2, 3, 4);
            var color = new Color();
            var result = _factory.CreateCircle(1, extent, color);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.X, Is.EqualTo(1d));
            Assert.That(result.Y, Is.EqualTo(2d));
            Assert.That(result.Radius, Is.EqualTo(1.5d));
            Assert.That(result.Color, Is.EqualTo(color));
        }

        [Test]
        public void TestCreateImageShouldCreateImage()
        {
            var extent = new Rect(1, 2, 3, 4);
            var image = new BitmapImage();
            var result = _factory.CreateImage(1, extent, image);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.X, Is.EqualTo(1d));
            Assert.That(result.Y, Is.EqualTo(2d));
            Assert.That(result.Width, Is.EqualTo(3d));
            Assert.That(result.Height, Is.EqualTo(4d));
            Assert.That(result.Image, Is.EqualTo(image));
        }

        [Test]
        public void TestCreateLabelShouldCreateLabel()
        {
            var origin = new Point(1, 2);
            var text = "Test";
            var result = _factory.CreateLabel(1, origin, text);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.X, Is.EqualTo(1d));
            Assert.That(result.Y, Is.EqualTo(2d));
            Assert.That(result.IsRotated, Is.False);
            Assert.That(result.Text, Is.EqualTo(text));
        }
    }
}

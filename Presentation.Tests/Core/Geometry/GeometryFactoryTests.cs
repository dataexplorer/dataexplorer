using System.Windows;
using System.Windows.Media;
using DataExplorer.Presentation.Core.Geometry;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Core.Geometry
{
    [TestFixture]
    public class GeometryFactoryTests
    {
        private GeometryFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new GeometryFactory();
        }

        [Test]
        public void TestCreateCircleShouldCreateCircleBasedOnExtent()
        {
            var extent = new Rect(1, 2, 3, 4);
            var color = new Color();
            var result = _factory.CreateCircle(1, extent, color);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.X, Is.EqualTo(1));
            Assert.That(result.Y, Is.EqualTo(2));
            Assert.That(result.Radius, Is.EqualTo(1.5d));
            Assert.That(result.Color, Is.EqualTo(color));
        }

        [Test]
        public void TestCreateLabelShouldCreateLabelBasedOnExtent()
        {
            var origin = new Point(1, 2);
            var text = "Test";
            var result = _factory.CreateLabel(1, origin, text);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.X, Is.EqualTo(1));
            Assert.That(result.Y, Is.EqualTo(2));
            Assert.That(result.IsRotated, Is.False);
            Assert.That(result.Text, Is.EqualTo(text));
        }
    }
}

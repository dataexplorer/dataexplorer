using System.Windows;
using DataExplorer.Presentation.Core.Geometry;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Core.Geometry
{
    [TestFixture]
    public class GeometryCalculatorTests
    {
        private GeometryCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new GeometryCalculator();    
        }
        
        [Test]
        public void TestCalculateExtentShouldCalculateExtentOfGeometry()
        {
            var controlSize = new Size(0, 0);
            var viewExtent = new Rect(0, 0, 0, 0);
            var plotCenter = new Point(0, 0);
            var plotExtent = new Rect(0, 0, 16, 16);
            var scale = 1;
            var result = _calculator.CalculateExtent(controlSize, viewExtent, scale, plotCenter);
            Assert.That(result, Is.EqualTo(plotExtent));
        }

        [Test]
        public void TestCalculateExtentShouldCalculateCenterOfPlot()
        {
            var controlSize = new Size(0, 0);
            var viewExtent = new Rect(0, 0, 0, 0);
            var plotCenter = new Point(1, 2);
            var plotExtent = new Rect(1, -2, 16, 16);
            var scale = 1;
            var result = _calculator.CalculateExtent(controlSize, viewExtent, scale, plotCenter);
            Assert.That(result, Is.EqualTo(plotExtent));
        }

        [Test]
        public void TestCalculateExtentSubtractViewOrigin()
        {
            var controlSize = new Size(0, 0);
            var viewExtent = new Rect(1, 2, 0, 0);
            var plotCenter = new Point(3, 4);
            var plotExtent = new Rect(2, -2, 16, 16);
            var scale = 1;
            var result = _calculator.CalculateExtent(controlSize, viewExtent, scale, plotCenter);
            Assert.That(result, Is.EqualTo(plotExtent));
        }

        [Test]
        public void TestCalculateExtentShouldScaleExtent()
        {
            var controlSize = new Size(0, 0);
            var viewExtent = new Rect(0, 0, 0, 0);
            var plotCenter = new Point(1, 2);
            var plotExtent = new Rect(2, -4, 16, 16);
            var scale = 2;
            var result = _calculator.CalculateExtent(controlSize, viewExtent, scale, plotCenter);
            Assert.That(result, Is.EqualTo(plotExtent));
        }

        [Test]
        public void TestCalculateExtentShouldSubtractControlHeight()
        {
            var controlSize = new Size(0, 10);
            var viewExtent = new Rect(0, 0, 0, 0);
            var plotCenter = new Point(0, 0);
            var plotExtent = new Rect(0, 10, 16, 16);
            var scale = 1;
            var result = _calculator.CalculateExtent(controlSize, viewExtent, scale, plotCenter);
            Assert.That(result, Is.EqualTo(plotExtent));
        }
    }
}

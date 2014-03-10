using System.Windows;
using DataExplorer.Presentation.Core.Geometry;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Core.Geometry
{
    [TestFixture]
    public class GeometryCalculatorTests
    {
        private GeometryCalculator _calculator;
        private Size _controlSize;
        private Rect _viewExtent;
        private Point _plotCenter;
        private Rect _plotExtent;
        private double _scale;
        private double _plotSize;

        [SetUp]
        public void SetUp()
        {
            _controlSize = new Size(0, 0);
            _viewExtent = new Rect(0, 0, 0, 0);
            _plotCenter = new Point(0, 0);
            _plotExtent = new Rect(0, 0, 0, 0);
            _scale = 1d;
            _plotSize = 0d;

            _calculator = new GeometryCalculator();    
        }

        [Test]
        public void TestCalculateExtentShouldCalculateExtentOfGeometry()
        {
            _plotSize = 1d;
            var result = _calculator.CalculatePlotExtent(_controlSize, _viewExtent, _scale, _plotCenter, _plotSize);
            Assert.That(result, Is.EqualTo(new Rect(0, 0, 128, 128)));
        }

        [Test]
        public void TestCalculateExtentShouldCalculateCenterOfPlot()
        {
            _plotCenter = new Point(1, 2);
            var result = _calculator.CalculatePlotExtent(_controlSize, _viewExtent, _scale, _plotCenter, _plotSize);
            Assert.That(result, Is.EqualTo(new Rect(1, -2, 0, 0)));
        }

        [Test]
        public void TestCalculateExtentSubtractViewOrigin()
        {
            _viewExtent = new Rect(1, 2, 0, 0);
            _plotCenter = new Point(3, 4);
            var result = _calculator.CalculatePlotExtent(_controlSize, _viewExtent, _scale, _plotCenter, _plotSize);
            Assert.That(result, Is.EqualTo(new Rect(2, -2, 0, 0)));
        }

        [Test]
        public void TestCalculateExtentShouldScaleExtent()
        {
            _plotCenter = new Point(1, 2);
            _scale = 2;
            var result = _calculator.CalculatePlotExtent(_controlSize, _viewExtent, _scale, _plotCenter, _plotSize);
            Assert.That(result, Is.EqualTo(new Rect(2, -4, 0, 0)));
        }

        [Test]
        public void TestCalculateExtentShouldSubtractControlHeight()
        {
            _controlSize = new Size(0, 10);
            var result = _calculator.CalculatePlotExtent(_controlSize, _viewExtent, _scale, _plotCenter, _plotSize);
            Assert.That(result, Is.EqualTo(new Rect(0, 10, 0, 0)));
        }

        [Test]
        public void TestCalculateLabelOriginShouldCalculateLocationOfLabelRelativeToPlot()
        {
            _plotExtent = new Rect(0, 0, 4, 4);
            var result = _calculator.CalcluateLabelOrigin(_plotExtent);
            Assert.That(result.X, Is.EqualTo(0));
            Assert.That(result.Y, Is.EqualTo(17));
        }
    }
}

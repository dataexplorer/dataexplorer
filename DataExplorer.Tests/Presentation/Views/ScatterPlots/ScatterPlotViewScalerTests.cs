using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Views.ScatterPlots;
using DataExplorer.Presentation.Views.ScatterPlots.Scalers;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotViewScalerTests
    {
        private ScatterPlotViewScaler _scaler;
        private Mock<IPointScaler> _mockPointScaler;
        private Mock<IVectorScaler> _mockVectorScaler;

        [SetUp]
        public void SetUp()
        {
            _mockPointScaler = new Mock<IPointScaler>();
            _mockVectorScaler = new Mock<IVectorScaler>();
            _scaler = new ScatterPlotViewScaler(
                _mockPointScaler.Object,
                _mockVectorScaler.Object);
        }

        [Test]
        public void TestScalePointShouldScalePoint()
        {
            var point = new Point(1, 2);
            var controlSize = new Size();
            var viewExtent = new Rect();
            var scaledPoint = new Point(3, 4);
            _mockPointScaler.Setup(p => p.ScalePoint(point, controlSize, viewExtent)).Returns(scaledPoint);
            var result = _scaler.ScalePoint(point, controlSize, viewExtent);
            Assert.That(result, Is.EqualTo(scaledPoint));
        }

        [Test]
        public void TestScaleVectorShouldScaleVector()
        {
            var vector = new Vector(1, 2);
            var controlSize = new Size();
            var viewExtent = new Rect();
            var scaledVector = new Vector(3, 4);
            _mockVectorScaler.Setup(p => p.ScaleVector(vector, controlSize, viewExtent)).Returns(scaledVector);
            var result = _scaler.ScaleVector(vector, controlSize, viewExtent);
            Assert.That(result, Is.EqualTo(scaledVector));
        }
    }
}

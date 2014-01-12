using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Views.ScatterPlots.Scalers;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots.Scalers
{
    [TestFixture]
    public class PointScalerTests
    {
        private PointScaler _scaler;

        [SetUp]
        public void SetUp()
        {
            _scaler = new PointScaler();
        }

        [Test]
        public void TestScaleShouldScalePoint()
        {
            var center = new Point(0.5d, 0.5d);
            var controlSize = new Size(1d, 1d);
            var viewExtent = new Rect(0d, 0d, 1d, 1d);
            var result = _scaler.ScalePoint(center, controlSize, viewExtent);
            Assert.That(result.X, Is.EqualTo(0d));
            Assert.That(result.Y, Is.EqualTo(0d));
        }
    }
}

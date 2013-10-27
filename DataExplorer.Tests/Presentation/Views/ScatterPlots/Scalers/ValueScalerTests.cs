using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Views.ScatterPlots.Scalers;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots.Scalers
{
    [TestFixture]
    public class ValueScalerTests
    {
        private ValueScaler _scaler;
        private double _value;
        private double _fromX;
        private double _fromWidth;
        private double _toX;
        private double _toWidth;

        [SetUp]
        public void SetUp()
        {
            _value = 5;
            _fromX = 0;
            _fromWidth = 10;
            _toX = 0;
            _toWidth = 100;

            _scaler = new ValueScaler();
        }

        [Test]
        public void TestScaleShouldReturnScaledValue()
        {
            var result = _scaler.Scale(_value, _fromX, _fromWidth, _toX, _toWidth);
            Assert.That(result, Is.EqualTo(50));
        }
    }
}

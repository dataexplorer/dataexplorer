using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Core.Controls;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Core.Controls
{
    [TestFixture, RequiresSTA]
    public class RangeSliderTests
    {
        private RangeSlider _slider;

        [SetUp]
        public void SetUp()
        {
            _slider = new RangeSlider();
            _slider.Minimum = 0d;
            _slider.Maximum = 1d;
        }

        [Test]
        public void TestGetSetMinimum()
        {
            _slider.Minimum = 0.5d;
            var result = _slider.Minimum;
            Assert.That(result, Is.EqualTo(0.5d));
        }

        [Test]
        public void TestGetSetMaximum()
        {
            _slider.Maximum = 0.5d;
            var result = _slider.Maximum;
            Assert.That(result, Is.EqualTo(0.5d));
        }

        [Test]
        public void TestGetSetLowerValue()
        {
            _slider.LowerValue = 0.5d;
            var result = _slider.LowerValue;
            Assert.That(result, Is.EqualTo(0.5d));
        }

        [Test]
        public void TestSetLowerValueLessThanUpperValueShouldShouldNotChangeUpperValue()
        {
            _slider.UpperValue = 0.50d;
            _slider.LowerValue = 0.25d;
            var result = _slider.UpperValue;
            Assert.That(result, Is.EqualTo(0.50d));
        }

        [Test]
        public void TestSetLowerValueGreaterThanUpperValueShouldSetUpperValueToLowerValue()
        {
            _slider.UpperValue = 0.5d;
            _slider.LowerValue = 0.75d;
            var result = _slider.UpperValue;
            Assert.That(result, Is.EqualTo(0.75d));
        }

        [Test]
        public void TestGetSetUpperValue()
        {
            _slider.UpperValue = 0.5d;
            var result = _slider.UpperValue;
            Assert.That(result, Is.EqualTo(0.5d));
        }

        [Test]
        public void TestSetUpperValueGreaterThanLowerValueShouldShouldNotChangeLowerValue()
        {
            _slider.LowerValue = 0.50d;
            _slider.UpperValue = 0.75d;
            var result = _slider.LowerValue;
            Assert.That(result, Is.EqualTo(0.50d));
        }

        [Test]
        public void TestSetUpperValueLessThanThanLowerValueShouldSetLowerValueToUpperValue()
        {
            _slider.LowerValue = 0.50d;
            _slider.UpperValue = 0.25d;
            var result = _slider.LowerValue;
            Assert.That(result, Is.EqualTo(0.25d));
        }
    }
}

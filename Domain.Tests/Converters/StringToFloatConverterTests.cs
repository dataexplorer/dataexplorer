using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Converters;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.Converters
{
    [TestFixture]
    public class StringToFloatConverterTests
    {
        private StringToFloatConverter _converter;

        [SetUp]
        public void SetUp()
        {
            _converter = new StringToFloatConverter();
        }

        [Test]
        public void TestConverterShouldConvertNull()
        {
            var result = _converter.Convert(string.Empty);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void TestConverMinValue()
        {
            var result = _converter.Convert(double.MinValue.ToString("R"));
            Assert.That(result, Is.EqualTo(double.MinValue));
        }

        [Test]
        public void TestConverMaxValue()
        {
            var result = _converter.Convert(double.MaxValue.ToString("R"));
            Assert.That(result, Is.EqualTo(double.MaxValue));
        }
    }
}

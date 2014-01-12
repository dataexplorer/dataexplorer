using System;
using DataExplorer.Domain.Converters;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Converters
{
    [TestFixture]
    public class StringToIntegerConverterTest
    {
        private StringToIntegerConverter _converter;

        [SetUp]
        public void SetUp()
        {
            _converter = new StringToIntegerConverter();
        }

        [Test]
        public void TestConverterShouldConvertNull()
        {
            var result = _converter.Convert(string.Empty);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void TestConvertMinValue()
        {
            var result = _converter.Convert(Int32.MinValue.ToString());
            Assert.That(result, Is.EqualTo(Int32.MinValue));
        }

        [Test]
        public void TestConvertMaxValue()
        {
            var result = _converter.Convert(Int32.MaxValue.ToString());
            Assert.That(result, Is.EqualTo(Int32.MaxValue));
        }
    }
}

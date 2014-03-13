using System;
using DataExplorer.Domain.DataTypes.Converters;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.DataTypes.Converters
{
    [TestFixture]
    public class StringToDateTimeConverterTests
    {
        private StringToDateTimeConverter _converter;

        [SetUp]
        public void SetUp()
        {
            _converter = new StringToDateTimeConverter();
        }

        [Test]
        public void TestConverterShouldConvertNull()
        {
            var result = _converter.Convert(string.Empty);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void TestConvertDateTimeMin()
        {
            var result = _converter.Convert("1/1/0001 00:00:00.0000000");
            Assert.That(result, Is.EqualTo(DateTime.MinValue));
        }

        [Test]
        public void TestConvertDateTimeMax()
        {
            var result = _converter.Convert("12/31/9999 23:59:59.9999999");
            Assert.That(result, Is.EqualTo(DateTime.MaxValue));
        }
    }
}

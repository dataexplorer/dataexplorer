using DataExplorer.Domain.DataTypes.Converters;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.DataTypes.Converters
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

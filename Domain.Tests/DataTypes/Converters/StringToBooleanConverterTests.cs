using DataExplorer.Domain.DataTypes.Converters;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.DataTypes.Converters
{
    [TestFixture]
    public class StringToBooleanConverterTests
    {
        private StringToBooleanConverter _converter;

        [SetUp]
        public void SetUp()
        {
            _converter = new StringToBooleanConverter();
        }

        [Test]
        public void TestConverterShouldConvertNull()
        {
            var result = _converter.Convert(string.Empty);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void TestConvertShouldConvertTrue()
        {
            var result = _converter.Convert("true");
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestConvertShouldConvertFalse()
        {
            var result = _converter.Convert("false");
            Assert.That(result, Is.False);
        }
    }
}

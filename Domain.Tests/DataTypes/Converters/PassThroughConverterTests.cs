using DataExplorer.Domain.DataTypes.Converters;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.DataTypes.Converters
{
    [TestFixture]
    public class PassThroughConverterTests
    {
        private PassThroughConverter _converter;
        
        [SetUp]
        public void SetUp()
        {
            _converter = new PassThroughConverter();
        }

        [Test]
        public void TestConvertShouldPassValueThrough()
        {
            var result = _converter.Convert("Test");
            Assert.That(result, Is.EqualTo("Test"));
        }
    }
}

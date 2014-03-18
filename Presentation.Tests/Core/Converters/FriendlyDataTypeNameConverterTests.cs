using System;
using System.Windows.Media.Imaging;
using DataExplorer.Presentation.Core.Converters;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Core.Converters
{
    [TestFixture]
    public class FriendlyDataTypeNameConverterTests
    {
        private FriendlyDataTypeNameConverter _converter;

        [SetUp]
        public void SetUp()
        {
            _converter = new FriendlyDataTypeNameConverter();
        }

        [Test]
        [TestCase(typeof(Boolean), "Boolean")]
        [TestCase(typeof(DateTime), "DateTime")]
        [TestCase(typeof(Double), "Float")]
        [TestCase(typeof(Int32), "Integer")]
        [TestCase(typeof(String), "String")]
        [TestCase(typeof(BitmapImage), "Image")]
        public void TestConvertShouldReturnFriendlyName(Type type, string expected)
        {
            var result = _converter.Convert(type);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}

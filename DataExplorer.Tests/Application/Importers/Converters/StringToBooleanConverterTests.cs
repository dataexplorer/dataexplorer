using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Importers.Converters;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Importers.Converters
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

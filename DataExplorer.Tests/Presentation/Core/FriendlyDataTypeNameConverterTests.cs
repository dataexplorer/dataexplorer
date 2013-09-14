using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Core;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Core
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
        [TestCase(typeof(Double), "Double")]
        [TestCase(typeof(Int32), "Integer")]
        [TestCase(typeof(String), "String")]
        public void TestConvertShouldReturnFriendlyName(Type type, string expected)
        {
            var result = _converter.Convert(type);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}

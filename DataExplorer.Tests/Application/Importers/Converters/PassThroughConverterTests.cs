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

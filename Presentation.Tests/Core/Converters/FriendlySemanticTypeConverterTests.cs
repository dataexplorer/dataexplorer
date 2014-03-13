using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Semantics;
using DataExplorer.Presentation.Core.Converters;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Core.Converters
{
    [TestFixture]
    public class FriendlySemanticTypeConverterTests
    {
        private FriendlySemanticTypeNameConverter _converter;

        [SetUp]
        public void SetUp()
        {
            _converter = new FriendlySemanticTypeNameConverter();
        }

        [Test]
        [TestCase(SemanticType.Unknown, "")]
        [TestCase(SemanticType.Name, "Name")]
        [TestCase(SemanticType.Category, "Category")]
        [TestCase(SemanticType.Measure, "Measure")]
        [TestCase(SemanticType.Uri, "URI")]
        public void TestConvertShouldReturnFriendlyName(SemanticType semanticType, string expected)
        {
            var result = _converter.Convert(semanticType);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}

using System.Data;
using DataExplorer.Domain.Semantics;
using DataExplorer.Domain.Sources;
using DataExplorer.Domain.Sources.Maps;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Sources.Maps
{
    [TestFixture]
    public class SourceMapFactoryTests
    {
        private SourceMapFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new SourceMapFactory();
        }

        [Test]
        public void TestCreateShouldReturnNewSourceMap()
        {
            var column = new SourceColumn
            {
                Index = 1,
                Name = "Column 1",
                DataType = typeof(string),
                SemanticType = SemanticType.Measure
            };

            var result = _factory.Create(column.Index, column.Name, column.DataType, column.SemanticType);
            Assert.That(result.Index, Is.EqualTo(column.Index));
            Assert.That(result.Name, Is.EqualTo(column.Name));
            Assert.That(result.DataType, Is.EqualTo(column.DataType));
            Assert.That(result.SemanticType, Is.EqualTo(column.SemanticType));
        }
    }
}

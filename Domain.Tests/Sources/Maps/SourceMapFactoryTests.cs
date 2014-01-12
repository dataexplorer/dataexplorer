using System.Data;
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
            var column = new DataColumn("Column 1", typeof(string));
            var result = _factory.Create(column);
            Assert.That(result.Name, Is.EqualTo(column.ColumnName));
            Assert.That(result.SourceType, Is.EqualTo(column.DataType));
        }
    }
}

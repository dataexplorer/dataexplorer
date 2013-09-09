using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Sources.Maps;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.Sources.Maps
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
            var column = new DataColumn("Column 1");
            var result = _factory.Create(column);
            Assert.That(result.Name, Is.EqualTo(column.ColumnName));
        }
    }
}

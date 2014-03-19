using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Persistence.Common.Serializers;
using DataExplorer.Persistence.Filters.Serializers.StringFilters;
using DataExplorer.Persistence.Projects;
using DataExplorer.Persistence.Tests.Common.Serializers;
using DataExplorer.Persistence.Tests.Projects;
using NUnit.Framework;

namespace DataExplorer.Persistence.Tests.Filters.Serializers.StringFilters
{
    [TestFixture]
    public class StringFilterSerializerTests : SerializerTests
    {
        private StringFilterSerializer _serializer;
        private StringFilter _filter;
        private List<Column> _columns;
        private Column _column;
        private XElement _xFilter;
        
        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().WithId(1).Build();
            _columns = new List<Column> { _column };

            _filter = new StringFilter(_column, "test", true);

            _xFilter = new XElement("string-filter",
                new XElement("column-id", 1),
                new XElement("value", "test"),
                new XElement("include-null", true));
            
            _serializer = new StringFilterSerializer(
                new PropertySerializer(null));
        }

        [Test]
        public void TestSerializeShouldSerializerColumnId()
        {
            var result = _serializer.Serialize(_filter);
            AssertValue(result, "column-id", "1");
            AssertValue(result, "value", "test");
            AssertValue(result, "include-null", "true");
        }

        [Test]
        public void TestDeserializeShouldDeserializeColumn()
        {
            var result = _serializer.Deserialize(_xFilter, _columns);
            Assert.That(result.Column, Is.EqualTo(_column));
            Assert.That(result.Value, Is.EqualTo("test"));
            Assert.That(result.IncludeNull, Is.True);
        }
    }
}

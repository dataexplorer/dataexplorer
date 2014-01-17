using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters.StringFilters;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Infrastructure.Serializers.Filters.StringFilters;
using DataExplorer.Infrastructure.Serializers.Properties;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Infrastructure.Tests.Serializers.Filters.StringFilters
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

            _filter = new StringFilter(_column, "test");

            _xFilter = new XElement("integer-filter",
                new XElement("column-id", 1),
                new XElement("value", "test"));
            
            _serializer = new StringFilterSerializer(
                new PropertySerializer());
        }

        [Test]
        public void TestSerializeShouldSerializerColumnId()
        {
            var result = _serializer.Serialize(_filter);
            AssertValue(result, "column-id", "1");
            AssertValue(result, "value", "test");
        }

        [Test]
        public void TestDeserializeShouldDeserializeColumn()
        {
            var result = _serializer.Deserialize(_xFilter, _columns);
            Assert.That(result.Column, Is.EqualTo(_column));
            Assert.That(result.Value, Is.EqualTo("test"));
        }
    }
}

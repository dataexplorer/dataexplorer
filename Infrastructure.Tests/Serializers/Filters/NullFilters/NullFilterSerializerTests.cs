using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Infrastructure.Serializers.Filters.NullFilters;
using DataExplorer.Infrastructure.Serializers.Properties;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Infrastructure.Tests.Serializers.Filters.NullFilters
{
    [TestFixture]
    public class NullFilterSerializerTests : SerializerTests
    {
        private NullFilterSerializer _serializer;
        private NullFilter _filter;
        private List<Column> _columns;
        private Column _column;
        private XElement _xFilter;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().WithId(1).Build();
            _columns = new List<Column> { _column };
            _filter = new NullFilter(_column);

            _xFilter = new XElement("null-filter",
                new XElement("column-id", _column.Id));
            
            _serializer = new NullFilterSerializer(
                new PropertySerializer());
        }

        [Test]
        public void TestSerializeShouldSerializeFilter()
        {
            var result = _serializer.Serialize(_filter);
            Assert.That(result.Name.LocalName, Is.EqualTo("null-filter"));
        }

        [Test]
        public void TestSerializeShouldSerializeColumnId()
        {
            var result = _serializer.Serialize(_filter);
            AssertValue(result, "column-id", "1");
        }

        [Test]
        public void TestDeserializeShouldDeserializeColumn()
        {
            var result = _serializer.Deserialize(_xFilter, _columns);
            Assert.That(result.Column, Is.EqualTo(_column));
        }
    }
}

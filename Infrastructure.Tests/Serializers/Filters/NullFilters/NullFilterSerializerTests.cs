using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters.NullFilters;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Infrastructure.Serializers.Filters.NullFilters;
using DataExplorer.Infrastructure.Serializers.Properties;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Infrastructure.Tests.Serializers.Filters.NullFilters
{
    [TestFixture]
    public class NullFilterSerializerTests
    {
        private NullFilterSerializer _serializer;
        private Mock<IPropertySerializer> _mockPropertySerializer;
        private NullFilter _filter;
        private List<Column> _columns;
        private Column _column;
        private XElement _xFilter;
        private XElement _xColumnId;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().WithId(1).Build();
            _columns = new List<Column> { _column };
            _filter = new NullFilter(_column);

            _xFilter = new XElement("null-filter");
            _xColumnId = new XElement("column-id", _column.Id);
            _xFilter.Add(_xColumnId);

            _mockPropertySerializer = new Mock<IPropertySerializer>();
            _mockPropertySerializer.Setup(p => p.Serialize("column-id", _column.Id)).Returns(_xColumnId);
            _mockPropertySerializer.Setup(p => p.Deserialize<int>(_xColumnId)).Returns(_column.Id);

            _serializer = new NullFilterSerializer(_mockPropertySerializer.Object);
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
            var columnId = result.Elements().First(p => p.Name.LocalName == "column-id");
            Assert.That(columnId.Value, Is.EqualTo(_column.Id.ToString()));
        }

        [Test]
        public void TestDeserializeShouldDeserializeColumn()
        {
            var result = _serializer.Deserialize(_xFilter, _columns);
            Assert.That(result.Column, Is.EqualTo(_column));
        }
    }
}

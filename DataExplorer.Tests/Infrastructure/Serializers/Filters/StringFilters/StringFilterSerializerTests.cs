using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters.StringFilters;
using DataExplorer.Infrastructure.Serializers.Filters.StringFilters;
using DataExplorer.Infrastructure.Serializers.Properties;
using DataExplorer.Tests.Domain.Columns;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Infrastructure.Serializers.Filters.StringFilters
{
    [TestFixture]
    public class StringFilterSerializerTests
    {
        private StringFilterSerializer _serializer;
        private Mock<IPropertySerializer> _mockPropertySerializer;
        private StringFilter _filter;
        private List<Column> _columns;
        private Column _column;
        private XElement _xFilter;
        private XElement _xColumnId;
        private XElement _xValue;
        
        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().WithId(1).Build();
            _columns = new List<Column> { _column };

            _filter = new StringFilter(_column, "test");

            _xFilter = new XElement("integer-filter");
            _xColumnId = new XElement("column-id", 1);
            _xValue = new XElement("value", "test");
            _xFilter.Add(_xColumnId, _xValue);

            _mockPropertySerializer = new Mock<IPropertySerializer>();
            _mockPropertySerializer.Setup(p => p.Serialize("column-id", 1))
                .Returns(new XElement("column-id", 1));
            _mockPropertySerializer.Setup(p => p.Serialize("value", "test"))
                .Returns(new XElement("value", "test"));
            _mockPropertySerializer.Setup(p => p.Deserialize<int>(_xColumnId))
                .Returns(1);
            _mockPropertySerializer.Setup(p => p.Deserialize<string>(_xValue))
                .Returns("test");

            _serializer = new StringFilterSerializer(
                _mockPropertySerializer.Object);
        }

        [Test]
        public void TestSerializeShouldSerializerColumnId()
        {
            var result = _serializer.Serialize(_filter);
            AssertValue(result, "column-id", "1");
        }

        [Test]
        public void TestSerializeShouldSerializeValue()
        {
            var result = _serializer.Serialize(_filter);
            AssertValue(result, "value", "test");
        }
        
        private void AssertValue(XElement result, string name, string value)
        {
            Assert.That(result.Elements().First(p => p.Name.LocalName == name).Value,
                Is.EqualTo(value));
        }

        [Test]
        public void TestDeserializeShouldDeserializeColumn()
        {
            var result = _serializer.Deserialize(_xFilter, _columns);
            Assert.That(result.Column, Is.EqualTo(_column));
        }

        [Test]
        public void TestDeserializeShouldDeserializeValue()
        {
            var result = _serializer.Deserialize(_xFilter, _columns);
            Assert.That(result.Value, Is.EqualTo("test"));
        }
    }
}

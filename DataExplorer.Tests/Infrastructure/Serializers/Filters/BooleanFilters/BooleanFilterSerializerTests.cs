using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters.BooleanFilters;
using DataExplorer.Infrastructure.Serializers.Filters.BooleanFilters;
using DataExplorer.Infrastructure.Serializers.Properties;
using DataExplorer.Tests.Domain.Columns;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Infrastructure.Serializers.Filters.BooleanFilters
{
    [TestFixture]
    public class BooleanFilterSerializerTests
    {
        private BooleanFilterSerializer _serializer;
        private Mock<IPropertySerializer> _mockPropertySerializer;
        private BooleanFilter _filter;
        private List<Column> _columns; 
        private Column _column;
        private XElement _xFilter;
        private XElement _xColumnId;
        private XElement _xValues;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().WithId(1).Build();
            _columns = new List<Column> { _column };

            _filter = new BooleanFilter(_column, true);

            _xFilter = new XElement("boolean-filter");
            _xColumnId = new XElement("column-id", 1);
            _xValues = new XElement("values", new List<bool?> { true });
            _xFilter.Add(_xColumnId, _xValues);

            _mockPropertySerializer = new Mock<IPropertySerializer>();
            _mockPropertySerializer.Setup(p => p.Serialize("column-id", 1))
                .Returns(new XElement("column-id", 1));
            _mockPropertySerializer.Setup(p => p.SerializeList("values", It.IsAny<List<bool?>>()))
                .Returns(new XElement("values", new List<bool?> { true }));
            _mockPropertySerializer.Setup(p => p.Deserialize<int>(_xColumnId))
                .Returns(1);
            _mockPropertySerializer.Setup(p => p.DeserializeList<bool?>(_xValues))
                .Returns(new List<bool?> { true });
            
            _serializer = new BooleanFilterSerializer(
                _mockPropertySerializer.Object);
        }

        [Test]
        public void TestSerializeShouldSerializerColumnId()
        {
            var result = _serializer.Serialize(_filter);
            AssertValue(result, "column-id", "1");
        }

        [Test]
        public void TestSerializeShouldSerializeValues()
        {
            var result = _serializer.Serialize(_filter);
            AssertList(result, "values", "true");
        }

        [Test]
        public void TestDeserializeShouldDeserializeColumn()
        {
            var result = _serializer.Deserialize(_xFilter, _columns);
            Assert.That(result.Column, Is.EqualTo(_column));
        }

        [Test]
        public void TestDeserializeShouldDeserializeValues()
        {
            var result = _serializer.Deserialize(_xFilter, _columns);
            Assert.That(result.Values.Single(), Is.EqualTo(true));
        }

        private void AssertValue(XElement result, string name, string value)
        {
            Assert.That(result.Elements().First(p => p.Name.LocalName == name).Value, 
                Is.EqualTo(value));
        }

        private void AssertList(XElement result, string name, string value)
        {
            Assert.That(result.Elements()
                .First(p => p.Name.LocalName == name).Value, 
                Is.EqualTo(value));
        }
    }
}

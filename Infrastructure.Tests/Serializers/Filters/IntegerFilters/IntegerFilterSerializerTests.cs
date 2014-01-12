using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters.IntegerFilters;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Infrastructure.Serializers.Filters.IntegerFilters;
using DataExplorer.Infrastructure.Serializers.Properties;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Infrastructure.Tests.Serializers.Filters.IntegerFilters
{
    [TestFixture]
    public class IntegerFilterSerializerTests
    {
        private IntegerFilterSerializer _serializer;
        private Mock<IPropertySerializer> _mockPropertySerializer;
        private IntegerFilter _filter;
        private List<Column> _columns;
        private Column _column;
        private XElement _xFilter;
        private XElement _xColumnId;
        private XElement _xLowerValue;
        private XElement _xUpperValue;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().WithId(1).Build();
            _columns = new List<Column> { _column };

            _filter = new IntegerFilter(_column, Int32.MinValue, Int32.MaxValue);

            _xFilter = new XElement("integer-filter");
            _xColumnId = new XElement("column-id", 1);
            _xLowerValue = new XElement("lower-value", Int32.MinValue);
            _xUpperValue = new XElement("upper-value", Int32.MaxValue);
            _xFilter.Add(_xColumnId, _xLowerValue, _xUpperValue);

            _mockPropertySerializer = new Mock<IPropertySerializer>();
            _mockPropertySerializer.Setup(p => p.Serialize("column-id", 1))
                .Returns(new XElement("column-id", 1));
            _mockPropertySerializer.Setup(p => p.Serialize("lower-value", Int32.MinValue))
                .Returns(new XElement("lower-value", Int32.MinValue));
            _mockPropertySerializer.Setup(p => p.Serialize("upper-value", Int32.MaxValue))
                .Returns(new XElement("upper-value", Int32.MaxValue));
            _mockPropertySerializer.Setup(p => p.Deserialize<int>(_xColumnId))
                .Returns(1);
            _mockPropertySerializer.Setup(p => p.Deserialize<int>(_xLowerValue))
                .Returns(Int32.MinValue);
            _mockPropertySerializer.Setup(p => p.Deserialize<int>(_xUpperValue))
                .Returns(Int32.MaxValue);

            _serializer = new IntegerFilterSerializer(
                _mockPropertySerializer.Object);
        }

        [Test]
        public void TestSerializeShouldSerializerColumnId()
        {
            var result = _serializer.Serialize(_filter);
            AssertValue(result, "column-id", "1");
        }

        [Test]
        public void TestSerializeShouldSerializeLowerValue()
        {
            var result = _serializer.Serialize(_filter);
            AssertValue(result, "lower-value", Int32.MinValue.ToString());
        }

        [Test]
        public void TestSerializeShouldSerializeUpperValue()
        {
            var result = _serializer.Serialize(_filter);
            AssertValue(result, "upper-value", Int32.MaxValue.ToString());
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
        public void TestDeserializeShouldDeserializeLowerValue()
        {
            var result = _serializer.Deserialize(_xFilter, _columns);
            Assert.That(result.LowerValue, Is.EqualTo(Int32.MinValue));
        }

        [Test]
        public void TestDeserializeShouldDeserializeUpperValue()
        {
            var result = _serializer.Deserialize(_xFilter, _columns);
            Assert.That(result.UpperValue, Is.EqualTo(Int32.MaxValue));
        }
    }
}

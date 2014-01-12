using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters.FloatFilters;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Infrastructure.Serializers.Filters.FloatFilters;
using DataExplorer.Infrastructure.Serializers.Properties;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Infrastructure.Tests.Serializers.Filters.FloatFilters
{
    [TestFixture]
    public class FloatFilterSerializerTests
    {
        private FloatFilterSerializer _serializer;
        private Mock<IPropertySerializer> _mockPropertySerializer;
        private FloatFilter _filter;
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

            _filter = new FloatFilter(_column, 0d, 1d);

            _xFilter = new XElement("float-filter");
            _xColumnId = new XElement("column-id", 1);
            _xLowerValue = new XElement("lower-value", 0d);
            _xUpperValue = new XElement("upper-value", 1d);
            _xFilter.Add(_xColumnId, _xLowerValue, _xUpperValue);

            _mockPropertySerializer = new Mock<IPropertySerializer>();
            _mockPropertySerializer.Setup(p => p.Serialize("column-id", 1))
                .Returns(new XElement("column-id", 1));
            _mockPropertySerializer.Setup(p => p.Serialize("lower-value", 0d))
                .Returns(new XElement("lower-value", 0d));
            _mockPropertySerializer.Setup(p => p.Serialize("upper-value", 1d))
                .Returns(new XElement("upper-value", 1d));
            _mockPropertySerializer.Setup(p => p.Deserialize<int>(_xColumnId))
                .Returns(1);
            _mockPropertySerializer.Setup(p => p.Deserialize<Double>(_xLowerValue))
                .Returns(0d);
            _mockPropertySerializer.Setup(p => p.Deserialize<Double>(_xUpperValue))
                .Returns(1d);

            _serializer = new FloatFilterSerializer(
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
            AssertValue(result, "lower-value", "0");
        }

        [Test]
        public void TestSerializeShouldSerializeUpperValue()
        {
            var result = _serializer.Serialize(_filter);
            AssertValue(result, "upper-value", "1");
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
            Assert.That(result.LowerValue, Is.EqualTo(0d));
        }

        [Test]
        public void TestDeserializeShouldDeserializeUpperValue()
        {
            var result = _serializer.Deserialize(_xFilter, _columns);
            Assert.That(result.UpperValue, Is.EqualTo(1d));
        }
    }
}

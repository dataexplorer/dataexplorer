using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters.DateTimeFilters;
using DataExplorer.Infrastructure.Serializers.Filters.DateTimeFilters;
using DataExplorer.Infrastructure.Serializers.Properties;
using DataExplorer.Tests.Domain.Columns;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Infrastructure.Serializers.Filters.DateTimeFilters
{
    [TestFixture]
    public class DateTimeFilterSerializerTests
    {
        private DateTimeFilterSerializer _serializer;
        private Mock<IPropertySerializer> _mockPropertySerializer;
        private DateTimeFilter _filter;
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

            _filter = new DateTimeFilter(_column, DateTime.MinValue, DateTime.MaxValue);

            _xFilter = new XElement("datetime-filter");
            _xColumnId = new XElement("column-id", 1);
            _xLowerValue = new XElement("lower-value", DateTime.MinValue);
            _xUpperValue = new XElement("upper-value", DateTime.MaxValue);
            _xFilter.Add(_xColumnId, _xLowerValue, _xUpperValue);

            _mockPropertySerializer = new Mock<IPropertySerializer>();
            _mockPropertySerializer.Setup(p => p.Serialize("column-id", 1))
                .Returns(new XElement("column-id", 1));
            _mockPropertySerializer.Setup(p => p.Serialize("lower-value", DateTime.MinValue))
                .Returns(new XElement("lower-value", DateTime.MinValue));
            _mockPropertySerializer.Setup(p => p.Serialize("upper-value", DateTime.MaxValue))
                .Returns(new XElement("upper-value", DateTime.MaxValue));
            _mockPropertySerializer.Setup(p => p.Deserialize<int>(_xColumnId))
                .Returns(1);
            _mockPropertySerializer.Setup(p => p.Deserialize<DateTime>(_xLowerValue))
                .Returns(DateTime.MinValue);
            _mockPropertySerializer.Setup(p => p.Deserialize<DateTime>(_xUpperValue))
                .Returns(DateTime.MaxValue);

            _serializer = new DateTimeFilterSerializer(
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
            AssertValue(result, "lower-value", DateTime.MinValue.ToString("s"));
        }

        [Test]
        public void TestSerializeShouldSerializeUpperValue()
        {
            var result = _serializer.Serialize(_filter);
            AssertValue(result, "upper-value", DateTime.MaxValue.ToString("O"));
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
            Assert.That(result.LowerValue, Is.EqualTo(DateTime.MinValue));
        }

        [Test]
        public void TestDeserializeShouldDeserializeUpperValue()
        {
            var result = _serializer.Deserialize(_xFilter, _columns);
            Assert.That(result.UpperValue, Is.EqualTo(DateTime.MaxValue));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Infrastructure.Serializers.Filters;
using DataExplorer.Infrastructure.Serializers.Filters.BooleanFilters;
using DataExplorer.Infrastructure.Serializers.Filters.DateTimeFilters;
using DataExplorer.Infrastructure.Serializers.Filters.FloatFilters;
using DataExplorer.Infrastructure.Serializers.Filters.IntegerFilters;
using DataExplorer.Infrastructure.Serializers.Filters.NullFilters;
using DataExplorer.Infrastructure.Serializers.Filters.StringFilters;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Infrastructure.Tests.Serializers.Filters
{
    [TestFixture]
    public class FilterSerializerTests
    {
        private FilterSerializer _serializer;
        private Mock<INullFilterSerializer> _mockNullSerializer;
        private Mock<IBooleanFilterSerializer> _mockBooleanSerializer;
        private Mock<IDateTimeFilterSerializer> _mockDateTimeSerializer;
        private Mock<IFloatFilterSerializer> _mockFloatSerializer;
        private Mock<IIntegerFilterSerializer> _mockIntegerSerializer;
        private Mock<IStringFilterSerializer> _mockStringSerializer;
        private Column _column;
        private List<Column> _columns;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().Build();
            _columns = new List<Column> { _column };

            _mockNullSerializer = new Mock<INullFilterSerializer>();
            _mockBooleanSerializer = new Mock<IBooleanFilterSerializer>();
            _mockDateTimeSerializer = new Mock<IDateTimeFilterSerializer>();
            _mockFloatSerializer = new Mock<IFloatFilterSerializer>();
            _mockIntegerSerializer = new Mock<IIntegerFilterSerializer>();
            _mockStringSerializer = new Mock<IStringFilterSerializer>();

            _serializer = new FilterSerializer(
                _mockNullSerializer.Object,
                _mockBooleanSerializer.Object,
                _mockDateTimeSerializer.Object,
                _mockFloatSerializer.Object,
                _mockIntegerSerializer.Object,
                _mockStringSerializer.Object);
        }

        [Test]
        public void TestSerializeShouldSerializeNullFilters()
        {
            var filter = new NullFilter(_column);
            var xFilter = new XElement("null-filter");
            _mockNullSerializer.Setup(p => p.Serialize(filter)).Returns(xFilter);
            var result = _serializer.Serialize(filter);
            Assert.That(result, Is.EqualTo(xFilter));
        }

        [Test]
        public void TestSerializeShouldSerializeBooleanFilters()
        {
            var filter = new BooleanFilter(_column, true, true, true);
            var xFilter = new XElement("boolean-filter");
            _mockBooleanSerializer.Setup(p => p.Serialize(filter)).Returns(xFilter);
            var result = _serializer.Serialize(filter);
            Assert.That(result, Is.EqualTo(xFilter));
        }

        [Test]
        public void TestSerializeShouldSerializeDateTimeFilters()
        {
            var filter = new DateTimeFilter(_column, DateTime.MinValue, DateTime.MaxValue, true);
            var xFilter = new XElement("datetime-filter");
            _mockDateTimeSerializer.Setup(p => p.Serialize(filter)).Returns(xFilter);
            var result = _serializer.Serialize(filter);
            Assert.That(result, Is.EqualTo(xFilter));
        }

        [Test]
        public void TestSerializeShouldSerializeFloatFilters()
        {
            var filter = new FloatFilter(_column, double.MinValue, double.MaxValue, true);
            var xFilter = new XElement("float-filter");
            _mockFloatSerializer.Setup(p => p.Serialize(filter)).Returns(xFilter);
            var result = _serializer.Serialize(filter);
            Assert.That(result, Is.EqualTo(xFilter));
        }

        [Test]
        public void TestSerializeShouldSerializeIntegerFilters()
        {
            var filter = new IntegerFilter(_column, int.MinValue, int.MaxValue, true);
            var xFilter = new XElement("integer-filter");
            _mockIntegerSerializer.Setup(p => p.Serialize(filter)).Returns(xFilter);
            var result = _serializer.Serialize(filter);
            Assert.That(result, Is.EqualTo(xFilter));
        }

        [Test]
        public void TestSerializeShouldSerializeStringFilters()
        {
            var filter = new StringFilter(_column, string.Empty, true);
            var xFilter = new XElement("string-filter");
            _mockStringSerializer.Setup(p => p.Serialize(filter)).Returns(xFilter);
            var result = _serializer.Serialize(filter);
            Assert.That(result, Is.EqualTo(xFilter));
        }

        [Test]
        public void TestDeserializeShouldDeserializeNullFilters()
        {
            var xFilter = new XElement("null-filter");
            var filter = new NullFilter(_column);
            _mockNullSerializer.Setup(p => p.Deserialize(xFilter, _columns)).Returns(filter);
            var result = _serializer.Deserialize(xFilter, _columns);
            Assert.That(result, Is.EqualTo(filter));
        }

        [Test]
        public void TestDeserializeShouldDeserializeBooleanFilters()
        {
            var xFilter = new XElement("boolean-filter");
            var filter = new BooleanFilter(_column, true, true, true);
            _mockBooleanSerializer.Setup(p => p.Deserialize(xFilter, _columns)).Returns(filter);
            var result = _serializer.Deserialize(xFilter, _columns);
            Assert.That(result, Is.EqualTo(filter));
        }

        [Test]
        public void TestDeserializeShouldDeserializeDateTimeFilters()
        {
            var xFilter = new XElement("datetime-filter");
            var filter = new DateTimeFilter(_column, DateTime.MinValue, DateTime.MaxValue, true);
            _mockDateTimeSerializer.Setup(p => p.Deserialize(xFilter, _columns)).Returns(filter);
            var result = _serializer.Deserialize(xFilter, _columns);
            Assert.That(result, Is.EqualTo(filter));
        }

        [Test]
        public void TestDeserializeShouldDeserializeFloatFilters()
        {
            var xFilter = new XElement("float-filter");
            var filter = new FloatFilter(_column, 0d, 1d, true);
            _mockFloatSerializer.Setup(p => p.Deserialize(xFilter, _columns)).Returns(filter);
            var result = _serializer.Deserialize(xFilter, _columns);
            Assert.That(result, Is.EqualTo(filter));
        }

        [Test]
        public void TestDeserializeShouldDeserializeIntegerFilters()
        {
            var xFilter = new XElement("integer-filter");
            var filter = new IntegerFilter(_column, 0, 1, true);
            _mockIntegerSerializer.Setup(p => p.Deserialize(xFilter, _columns)).Returns(filter);
            var result = _serializer.Deserialize(xFilter, _columns);
            Assert.That(result, Is.EqualTo(filter));
        }

        [Test]
        public void TestDeserializeShouldDeserializeStringFilters()
        {
            var xFilter = new XElement("string-filter");
            var filter = new StringFilter(_column, string.Empty, true);
            _mockStringSerializer.Setup(p => p.Deserialize(xFilter, _columns)).Returns(filter);
            var result = _serializer.Deserialize(xFilter, _columns);
            Assert.That(result, Is.EqualTo(filter));
        }
    }
}

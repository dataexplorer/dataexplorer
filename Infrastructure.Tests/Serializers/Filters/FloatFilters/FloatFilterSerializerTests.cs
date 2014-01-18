using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Infrastructure.Serializers.Filters.FloatFilters;
using DataExplorer.Infrastructure.Serializers.Properties;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Infrastructure.Tests.Serializers.Filters.FloatFilters
{
    [TestFixture]
    public class FloatFilterSerializerTests : SerializerTests
    {
        private FloatFilterSerializer _serializer;
        private FloatFilter _filter;
        private List<Column> _columns;
        private Column _column;
        private XElement _xFilter;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().WithId(1).Build();
            _columns = new List<Column> { _column };

            _filter = new FloatFilter(_column, 0d, 1d, true);

            _xFilter = new XElement("float-filter",
                new XElement("column-id", 1),
                new XElement("lower-value", 0d),
                new XElement("upper-value", 1d),
                new XElement("include-null", true));

            _serializer = new FloatFilterSerializer(
                new PropertySerializer());
        }

        [Test]
        public void TestSerializeShouldSerializerValues()
        {
            var result = _serializer.Serialize(_filter);
            AssertValue(result, "column-id", "1");
            AssertValue(result, "lower-value", "0");
            AssertValue(result, "upper-value", "1");
        }

        [Test]
        public void TestDeserializeShouldDeserializeValues()
        {
            var result = _serializer.Deserialize(_xFilter, _columns);
            Assert.That(result.Column, Is.EqualTo(_column));
            Assert.That(result.LowerValue, Is.EqualTo(0d));
            Assert.That(result.UpperValue, Is.EqualTo(1d));
        }
    }
}

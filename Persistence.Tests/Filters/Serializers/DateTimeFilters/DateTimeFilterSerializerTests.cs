using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Persistence.Filters.Serializers.DateTimeFilters;
using DataExplorer.Persistence.Projects;
using DataExplorer.Persistence.Tests.Projects;
using NUnit.Framework;

namespace DataExplorer.Persistence.Tests.Filters.Serializers.DateTimeFilters
{
    [TestFixture]
    public class DateTimeFilterSerializerTests : SerializerTests
    {
        private DateTimeFilterSerializer _serializer;
        private DateTimeFilter _filter;
        private List<Column> _columns;
        private Column _column;
        private XElement _xFilter;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().WithId(1).Build();
            _columns = new List<Column> { _column };

            _filter = new DateTimeFilter(_column, DateTime.MinValue, DateTime.MaxValue, true);

            _xFilter = new XElement("datetime-filter",
                new XElement("column-id", _column.Id),
                new XElement("lower-value", DateTime.MinValue),
                new XElement("upper-value", DateTime.MaxValue),
                new XElement("include-null", true));
           
            _serializer = new DateTimeFilterSerializer(
                new PropertySerializer());
        }

        [Test]
        public void TestSerializeShouldSerializerValues()
        {
            var result = _serializer.Serialize(_filter);
            AssertValue(result, "column-id", "1");
            AssertValue(result, "lower-value", DateTime.MinValue.ToString("s"));
            AssertValue(result, "upper-value", DateTime.MaxValue.ToString("O"));
            AssertValue(result, "include-null", "true");
        }
               
        [Test]
        public void TestDeserializeShouldDeserializeColumn()
        {
            var result = _serializer.Deserialize(_xFilter, _columns);
            Assert.That(result.Column, Is.EqualTo(_column));
            Assert.That(result.LowerValue, Is.EqualTo(DateTime.MinValue));
            Assert.That(result.UpperValue, Is.EqualTo(DateTime.MaxValue));
            Assert.That(result.IncludeNull, Is.True);
        }
    }
}

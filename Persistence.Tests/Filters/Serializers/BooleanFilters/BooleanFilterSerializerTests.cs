using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Persistence.Common.Serializers;
using DataExplorer.Persistence.Filters.Serializers.BooleanFilters;
using DataExplorer.Persistence.Tests.Common.Serializers;
using NUnit.Framework;

namespace DataExplorer.Persistence.Tests.Filters.Serializers.BooleanFilters
{
    [TestFixture]
    public class BooleanFilterSerializerTests : SerializerTests
    {
        private BooleanFilterSerializer _serializer;
        private BooleanFilter _filter;
        private List<Column> _columns; 
        private Column _column;
        private XElement _xFilter;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().WithId(1).Build();
            _columns = new List<Column> { _column };

            _filter = new BooleanFilter(_column, true, true, true);

            _xFilter = new XElement("boolean-filter",
                new XElement("column-id", 1),
                new XElement("include-true", true),
                new XElement("include-false", true),
                new XElement("include-null", true));
            
            _serializer = new BooleanFilterSerializer(
                new PropertySerializer(null));
        }

        [Test]
        public void TestSerializeShouldSerializeValues()
        {
            var result = _serializer.Serialize(_filter);
            AssertValue(result, "column-id", "1");
            AssertValue(result, "include-true", "true");
            AssertValue(result, "include-false", "true");
            AssertValue(result, "include-null", "true");
        }
        
        [Test]
        public void TestDeserializeShouldDeserializeValues()
        {
            var result = _serializer.Deserialize(_xFilter, _columns);
            Assert.That(result.Column, Is.EqualTo(_column));
            Assert.That(result.IncludeTrue, Is.True);
            Assert.That(result.IncludeFalse, Is.True);
            Assert.That(result.IncludeNull, Is.True);
        }
    }
}

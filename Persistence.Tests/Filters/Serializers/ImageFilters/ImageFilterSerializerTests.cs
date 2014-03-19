using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Persistence.Common.Serializers;
using DataExplorer.Persistence.Filters.Serializers.ImageFilters;
using DataExplorer.Persistence.Tests.Common.Serializers;
using NUnit.Framework;

namespace DataExplorer.Persistence.Tests.Filters.Serializers.ImageFilters
{
    [TestFixture]
    public class ImageFilterSerializerTests : SerializerTests
    {
        private ImageFilterSerializer _serializer;
        private ImageFilter _filter;
        private List<Column> _columns;
        private Column _column;
        private XElement _xFilter;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().WithId(1).Build();
            _columns = new List<Column> { _column };

            _filter = new ImageFilter(_column, true, true);

            _xFilter = new XElement("integer-filter",
                new XElement("column-id", 1),
                new XElement("include-null", true),
                new XElement("include-not-null", true));

            _serializer = new ImageFilterSerializer(
                new PropertySerializer(null));
        }

        [Test]
        public void TestSerializeShouldSerializerColumnId()
        {
            var result = _serializer.Serialize(_filter);
            AssertValue(result, "column-id", "1");
            AssertValue(result, "include-null", "true");
            AssertValue(result, "include-not-null", "true");
        }

        [Test]
        public void TestDeserializeShouldDeserializeColumn()
        {
            var result = _serializer.Deserialize(_xFilter, _columns);
            Assert.That(result.Column, Is.EqualTo(_column));
            Assert.That(result.IncludeNull, Is.True);
            Assert.That(result.IncludeNotNull, Is.True);
        }
    }
}

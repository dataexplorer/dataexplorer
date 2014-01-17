using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters.BooleanFilters;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Infrastructure.Serializers.Filters.BooleanFilters;
using DataExplorer.Infrastructure.Serializers.Properties;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Infrastructure.Tests.Serializers.Filters.BooleanFilters
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
        private XElement _xIncludeTrue;
        private XElement _xIncludeFalse;
        private XElement _xIncludeNull;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().WithId(1).Build();
            _columns = new List<Column> { _column };

            _filter = new BooleanFilter(_column, true, true, true);

            _xFilter = new XElement("boolean-filter");
            _xColumnId = new XElement("column-id", 1);
            _xIncludeTrue = new XElement("include-true", true);
            _xIncludeFalse = new XElement("include-false", true);
            _xIncludeNull = new XElement("include-null", true);
            _xFilter.Add(_xColumnId, _xIncludeTrue, _xIncludeFalse, _xIncludeNull);

            _mockPropertySerializer = new Mock<IPropertySerializer>();
            _mockPropertySerializer.Setup(p => p.Serialize("column-id", 1))
                .Returns(new XElement("column-id", 1));
            _mockPropertySerializer.Setup(p => p.Serialize("include-true", true))
                .Returns(new XElement("include-true", true));
            _mockPropertySerializer.Setup(p => p.Serialize("include-false", true))
                .Returns(new XElement("include-false", true));
            _mockPropertySerializer.Setup(p => p.Serialize("include-null", true))
                .Returns(new XElement("include-null", true));
            _mockPropertySerializer.Setup(p => p.Deserialize<int>(_xColumnId))
                .Returns(1);
            _mockPropertySerializer.Setup(p => p.Deserialize<bool>(_xIncludeTrue))
                .Returns(true);
            _mockPropertySerializer.Setup(p => p.Deserialize<bool>(_xIncludeFalse))
                .Returns(true);
            _mockPropertySerializer.Setup(p => p.Deserialize<bool>(_xIncludeNull))
                .Returns(true);
            
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
            AssertValue(result, "include-true", "true");
            AssertValue(result, "include-false", "true");
            AssertValue(result, "include-null", "true");
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
            Assert.That(result.IncludeTrue, Is.True);
            Assert.That(result.IncludeFalse, Is.True);
            Assert.That(result.IncludeNull, Is.True);
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

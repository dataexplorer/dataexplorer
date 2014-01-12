using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Infrastructure.Serializers;
using DataExplorer.Infrastructure.Serializers.Filters;
using DataExplorer.Tests.Domain.Filters;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Infrastructure.Serializers.Filters
{
    [TestFixture]
    public class FilterSetSerializerTests
    {
        private FilterSetSerializer _serializer;
        private Mock<IFilterSerializer> _mockFilterSerializer;
        private List<Filter> _filters;
        private Filter _filter;
        private List<Column> _columns;
        private XElement _xFilters;
        private XElement _xFilter;

        [SetUp]
        public void SetUp()
        {
            _filter = new FakeFilter();
            _filters = new List<Filter> { _filter };
            _columns = new List<Column>();

            _xFilter = new XElement("filter");
            _xFilters = new XElement("filters");
            _xFilters.Add(_xFilter);

            _mockFilterSerializer = new Mock<IFilterSerializer>();
            _mockFilterSerializer.Setup(p => p.Serialize(_filter)).Returns(_xFilter);
            _mockFilterSerializer.Setup(p => p.Deserialize(_xFilter, _columns)).Returns(_filter);

            _serializer = new FilterSetSerializer(_mockFilterSerializer.Object);
        }

        [Test]
        public void TestSerializeShouldReturnSerializedFilters()
        {
            var result = _serializer.Serialize(_filters);
            Assert.That(result.Name, Is.EqualTo(_xFilters.Name));
            Assert.That(result.Elements().Single().Name, Is.EqualTo(_xFilter.Name));
        }

        [Test]
        public void TestDeserializeShouldReturnDeserializedFilters()
        {
            var result = _serializer.Deserialize(_xFilters, _columns);
            Assert.That(result.Single(), Is.EqualTo(_filter));
        }
    }
}

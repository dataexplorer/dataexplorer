using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Sources;
using DataExplorer.Domain.Views;
using DataExplorer.Infrastructure.Serializers;
using DataExplorer.Infrastructure.Serializers.Columns;
using DataExplorer.Infrastructure.Serializers.Filters;
using DataExplorer.Infrastructure.Serializers.Rows;
using DataExplorer.Infrastructure.Serializers.Sources;
using DataExplorer.Infrastructure.Serializers.Views;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Infrastructure.Tests.Serializers
{
    [TestFixture]
    public class ProjectSerializerTests
    {
        private ProjectSerializer _serializer;
        private Mock<ISourceSetSerializer> _mockSourceSerializer;
        private Mock<IColumnDataTypeSerializer> _mockColumnDataTypeSerializer;
        private Mock<IColumnSetSerializer> _mockColumnSerializer;
        private Mock<IRowSetSerializer> _mockRowSerializer;
        private Mock<IFilterSetSerializer> _mockFilterSerializer;
        private Mock<IViewSetSerializer> _mockViewSerializer;
        private Project _project;
        private List<ISource> _sources;
        private List<Type> _dataTypes;
        private List<Column> _columns;
        private List<Row> _rows;
        private List<Filter> _filters;
        private List<IView> _views;
        private XElement _xProject;
        private XElement _xSources;
        private XElement _xColumns;
        private XElement _xRows;
        private XElement _xFilters;
        private XElement _xViews;

        [SetUp]
        public void SetUp()
        {
            _sources = new List<ISource>();
            _dataTypes = new List<Type>();
            _columns = new List<Column>();
            _rows = new List<Row>();
            _filters = new List<Filter>();
            _views = new List<IView>();

            _project = new Project()
            {
                Sources = _sources,
                Columns = _columns,
                Rows = _rows,
                Filters = _filters,
                Views = _views
            };
            
            _xProject = new XElement("project");
            _xSources = new XElement("sources");
            _xColumns = new XElement("columns");
            _xRows = new XElement("rows");
            _xFilters = new XElement("filters");
            _xViews = new XElement("views");
            _xProject.Add(_xSources, _xColumns, _xRows, _xFilters, _xViews);
            
            _mockSourceSerializer = new Mock<ISourceSetSerializer>();
            _mockSourceSerializer.Setup(p => p.Serialize(_sources)).Returns(_xSources);
            _mockSourceSerializer.Setup(p => p.Deserialize(_xSources)).Returns(_sources);

            _mockColumnDataTypeSerializer = new Mock<IColumnDataTypeSerializer>();
            _mockColumnDataTypeSerializer.Setup(p => p.Deserialize(_xColumns)).Returns(_dataTypes);

            _mockColumnSerializer = new Mock<IColumnSetSerializer>();
            _mockColumnSerializer.Setup(p => p.Serialize(_columns)).Returns(_xColumns);
            _mockColumnSerializer.Setup(p => p.Deserialize(_xColumns, _rows)).Returns(_columns);

            _mockRowSerializer = new Mock<IRowSetSerializer>();
            _mockRowSerializer.Setup(p => p.Serialize(_rows, _columns)).Returns(_xRows);
            _mockRowSerializer.Setup(p => p.Deserialize(_xRows, _dataTypes)).Returns(_rows);

            _mockFilterSerializer = new Mock<IFilterSetSerializer>();
            _mockFilterSerializer.Setup(p => p.Serialize(_filters)).Returns(_xFilters);
            _mockFilterSerializer.Setup(p => p.Deserialize(_xFilters, _columns)).Returns(_filters);

            _mockViewSerializer = new Mock<IViewSetSerializer>();
            _mockViewSerializer.Setup(p => p.Serialize(_views)).Returns(_xViews);
            _mockViewSerializer.Setup(p => p.Deserialize(_xViews, _columns)).Returns(_views);

            _serializer = new ProjectSerializer(
                _mockSourceSerializer.Object,
                _mockColumnDataTypeSerializer.Object,
                _mockColumnSerializer.Object,
                _mockRowSerializer.Object,
                _mockFilterSerializer.Object,
                _mockViewSerializer.Object);
        }

        [Test]
        public void TestSerializeShouldSerializeSources()
        {
            var result = _serializer.Serialize(_project);
            AssertCollectionExists(result, "sources");
        }

        [Test]
        public void TestSerializeShouldSerializeColumns()
        {
            var result = _serializer.Serialize(_project);
            AssertCollectionExists(result, "columns");
        }

        [Test]
        public void TestSerializeShouldSerializeRows()
        {
            var result = _serializer.Serialize(_project);
            AssertCollectionExists(result, "rows");
        }

        [Test]
        public void TestSerializeShouldSerializeFilters()
        {
            var result = _serializer.Serialize(_project);
            AssertCollectionExists(result, "filters");
        }

        [Test]
        public void TestSerializeShouldSerializeViews()
        {
            var result = _serializer.Serialize(_project);
            AssertCollectionExists(result, "views");
        }

        private void AssertCollectionExists(XElement xProject, string collectionTag)
        {
            var sources = xProject.Element(collectionTag);
            Assert.That(sources, Is.Not.Null);
        }

        [Test]
        public void TestDeserializeShouldDeserializeSources()
        {
            var result = _serializer.Deserialize(_xProject);
            Assert.That(result.Sources, Is.Empty);
        }

        [Test]
        public void TestDeserializeShouldDeserializeColumns()
        {
            var result = _serializer.Deserialize(_xProject);
            Assert.That(result.Columns, Is.Empty);
        }

        [Test]
        public void TestDeserializeShouldDeserializeRows()
        {
            var result = _serializer.Deserialize(_xProject);
            Assert.That(result.Rows, Is.Empty);
        }

        [Test]
        public void TestDeserializeShouldDeserializeFilters()
        {
            var result = _serializer.Deserialize(_xProject);
            Assert.That(result.Filters, Is.Empty);
        }

        [Test]
        public void TestDeserializeShouldDeserializeViews()
        {
            var result = _serializer.Deserialize(_xProject);
            Assert.That(result.Views, Is.Empty);
        }
    }
}

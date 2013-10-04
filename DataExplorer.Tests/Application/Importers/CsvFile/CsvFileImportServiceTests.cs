using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Importers;
using DataExplorer.Application.Importers.CsvFiles;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Converters;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Sources;
using DataExplorer.Domain.Sources.Maps;
using DataExplorer.Infrastructure.Importers.CsvFile;
using DataExplorer.Persistence;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Importers.CsvFile
{
    [TestFixture]
    public class CsvFileImportServiceTests
    {
        private CsvFileImportService _service;
        private Mock<ICsvFileDataAdapter> _mockDataAdapter;
        private Mock<IDataTypeConverterFactory> _mockFactory;
        private Mock<ISourceRepository> _mockRepository;
        private Mock<IRowRepository> _mockRowRepository;
        private Mock<IColumnRepository> _mockColumnRepository;
        private Mock<IDataContext> _mockDataContext;
        private Mock<ISourceMapFactory> _mockSourceMapFactory;
        private Mock<ICsvFileSourceAdapter> _mockAdapter;
        private CsvFileSource _source;
        private CsvFileSourceDto _sourceDto;

        [SetUp]
        public void SetUp()
        {
            _source = new CsvFileSource();
            _sourceDto = new CsvFileSourceDto();
            _mockDataAdapter = new Mock<ICsvFileDataAdapter>();
            _mockFactory = new Mock<IDataTypeConverterFactory>();
            _mockRepository = new Mock<ISourceRepository>();
            _mockRowRepository = new Mock<IRowRepository>();
            _mockColumnRepository = new Mock<IColumnRepository>();
            _mockDataContext = new Mock<IDataContext>();
            _mockSourceMapFactory = new Mock<ISourceMapFactory>();
            _mockAdapter = new Mock<ICsvFileSourceAdapter>();
            _service = new CsvFileImportService(
                _mockRepository.Object,
                _mockDataAdapter.Object,
                _mockFactory.Object,
                _mockRowRepository.Object,
                _mockColumnRepository.Object,
                _mockDataContext.Object,
                _mockSourceMapFactory.Object,
                _mockAdapter.Object);
        }

        [Test]
        public void TestGetSourceShouldReturnSourceDto()
        {
            _sourceDto.FilePath = @"C:\Test.xml";
            _mockRepository.Setup(p => p.GetSource<CsvFileSource>()).Returns(_source);
            _mockAdapter.Setup(p => p.Adapt(_source)).Returns(_sourceDto);
            var result = _service.GetSource();
            Assert.That(result.FilePath, Is.EqualTo(@"C:\Test.xml"));
        }

        [Test]
        public void TestUpdateSourceShouldUpdateSource()
        {
            _mockRepository.Setup(p => p.GetSource<CsvFileSource>()).Returns(_source);
            _mockDataAdapter.Setup(p => p.GetDataColumns(_source)).Returns(new List<DataColumn>());
            _service.UpdateSource(@"C:\Test.csv");
            Assert.That(_source.FilePath, Is.EqualTo(@"C:\Test.csv"));
        }
        
        [Test]
        public void TestCreateMapsShouldCreateMaps()
        {
            var column = new DataColumn();
            var columns = new List<DataColumn> { column };
            var map = new SourceMap() { };
            _mockRepository.Setup(p => p.GetSource<CsvFileSource>()).Returns(_source);
            _mockDataAdapter.Setup(p => p.Exists(_source)).Returns(true);
            _mockDataAdapter.Setup(p => p.GetDataColumns(_source)).Returns(columns);
            _mockSourceMapFactory.Setup(p => p.Create(column)).Returns(map);
            _service.UpdateSource(@"C:\Test.csv");
            Assert.That(_source.GetMaps(), Contains.Item(map));
        }

        [Test]
        public void TestGetMapsShouldReturnMaps()
        {
            var map = new SourceMap();
            var maps = new List<SourceMap> { map };
            _source.SetMaps(maps);
            _mockRepository.Setup(p => p.GetSource<CsvFileSource>()).Returns(_source);
            var result = _service.GetMaps();
            Assert.That(result, Contains.Item(map));
        }

        [Test]
        public void TestCanImportShouldReturnTrueIfFilePathExists()
        {
            _source.FilePath = @"C:\Test.csv";
            _mockRepository.Setup(p => p.GetSource<CsvFileSource>()).Returns(_source);
            var result = _service.CanImport();
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestCanImportShouldReturnFalseIfFilePathIsNull()
        {
            _source.FilePath = null;
            _mockRepository.Setup(p => p.GetSource<CsvFileSource>()).Returns(_source);
            var result = _service.CanImport();
            Assert.That(result, Is.False);
        }

        [Test]
        public void TestCanImportShouldReturnFalseIfFilePathIsEmpty()
        {
            _source.FilePath = string.Empty;
            _mockRepository.Setup(p => p.GetSource<CsvFileSource>()).Returns(_source);
            var result = _service.CanImport();
            Assert.That(result, Is.False);
        }

        // TODO: This needs to be separated when I extract this logic into separate components
        [Test]
        public void TestImportShouldImportData()
        {
            var wasImportingEventRaised = false;
            var wasImportedEventRaised = false;
            var wasProgressChangedEventRaised = false;
            var column = new DataColumn("Column 1", typeof(string));
            var columns = new List<DataColumn> { column };
            var dataTable = new DataTable();
            var rows = new List<Row>();
            dataTable.Columns.Add(column);
            dataTable.Rows.Add("Row 1");
            AppEvents.Register<CsvFileImportingEvent>(p => { wasImportingEventRaised = true; });
            _mockRepository.Setup(p => p.GetSource<CsvFileSource>()).Returns(_source);
            _mockDataAdapter.Setup(p => p.GetDataColumns(_source)).Returns(columns);
            _mockDataAdapter.Setup(p => p.GetDataTable(_source)).Returns(dataTable);
            _mockFactory.Setup(p => p.Create(typeof(string), typeof(string))).Returns(new PassThroughConverter());
            _mockRowRepository.Setup(p => p.Add(It.IsAny<Row>())).Callback<Row>(p => rows.Add(p));
            _mockRowRepository.Setup(p => p.GetAll()).Returns(rows);
            AppEvents.Register<CsvFileImportProgressChangedEvent>(p => { wasProgressChangedEventRaised = true; });
            AppEvents.Register<CsvFileImportedEvent>(p => { wasImportedEventRaised = true; });
            _service.Import();
            Assert.That(wasImportingEventRaised, Is.True);
            _mockDataContext.Verify(p => p.Clear(), Times.Once());
            _mockRepository.Verify(p => p.SetSource(_source), Times.Once());
            _mockColumnRepository.Verify(p => p.Add(It.IsAny<Column>()), Times.Once());
            _mockRowRepository.Verify(p => p.Add(It.IsAny<Row>()), Times.Once());
            Assert.That(wasProgressChangedEventRaised, Is.True);
            Assert.That(wasImportedEventRaised, Is.True);
            AppEvents.ClearHandlers();
        }
    }
}

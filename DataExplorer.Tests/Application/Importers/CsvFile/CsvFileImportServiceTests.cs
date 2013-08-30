using System.Collections.Generic;
using System.Data;
using DataExplorer.Application.Events;
using DataExplorer.Application.Importers;
using DataExplorer.Application.Importers.CsvFile;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Converters;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Sources;
using DataExplorer.Persistence;
using DataExplorer.Persistence.Columns;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Importers.CsvFile
{
    [TestFixture]
    public class CsvFileImportServiceTests
    {
        private CsvFileImportService _service;
        private Mock<ICsvFileAdapter> _mockAdapter;
        private Mock<IDataTypeConverterFactory> _mockFactory;
        private Mock<ISourceRepository> _mockRepository;
        private Mock<IRowRepository> _mockRowRepository;
        private Mock<IColumnRepository> _mockColumnRepository;
        private Mock<IDataContext> _mockDataContext;
        private CsvFileSource _source;

        [SetUp]
        public void SetUp()
        {
            _source = new CsvFileSource();
            _mockAdapter = new Mock<ICsvFileAdapter>();
            _mockFactory = new Mock<IDataTypeConverterFactory>();
            _mockRepository = new Mock<ISourceRepository>();
            _mockRowRepository = new Mock<IRowRepository>();
            _mockColumnRepository = new Mock<IColumnRepository>();
            _mockDataContext = new Mock<IDataContext>();
            _service = new CsvFileImportService(
                _mockRepository.Object,
                _mockAdapter.Object,
                _mockFactory.Object,
                _mockRowRepository.Object,
                _mockColumnRepository.Object,
                _mockDataContext.Object);
        }

        [Test]
        public void TestGetFilePathShouldReturnFilePath()
        {
            _source.FilePath = @"C:\Test.xml";
            _mockRepository.Setup(p => p.GetSource<CsvFileSource>()).Returns(_source);
            var result = _service.GetFilePath();
            Assert.That(result, Is.EqualTo(@"C:\Test.xml"));
        }

        [Test]
        public void TestSetFilePathShouldSetFilePathOfImporter()
        {
            _mockRepository.Setup(p => p.GetSource<CsvFileSource>()).Returns(_source);
            _service.SetFilePath(@"C:\Test.csv");
            Assert.That(_source.FilePath, Is.EqualTo(@"C:\Test.csv"));
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

        // TODO: Should I separate testing data being added to repository and event being raised?
        [Test]
        public void TestImportShouldImportData()
        {
            var wasRaised = true;
            var column = new DataColumn("Column 1", typeof(string));
            var columns = new List<DataColumn> { column };
            var dataTable = new DataTable();
            var rows = new List<Row>();
            dataTable.Columns.Add(column);
            dataTable.Rows.Add("Row 1");
            _mockRepository.Setup(p => p.GetSource<CsvFileSource>()).Returns(_source);
            _mockAdapter.Setup(p => p.GetDataColumns(_source)).Returns(columns);
            _mockAdapter.Setup(p => p.GetDataTable(_source)).Returns(dataTable);
            _mockFactory.Setup(p => p.Create(typeof(string), typeof(string))).Returns(new PassThroughConverter());
            _mockRowRepository.Setup(p => p.Add(It.IsAny<Row>())).Callback<Row>(p => rows.Add(p));
            _mockRowRepository.Setup(p => p.GetAll()).Returns(rows);
            AppEvents.Register<CsvFileImportedEvent>(p => { wasRaised = true; });
            _service.Import();
            _mockDataContext.Verify(p => p.Clear(), Times.Once());
            _mockRepository.Verify(p => p.SetSource(_source), Times.Once());
            _mockColumnRepository.Verify(p => p.Add(It.IsAny<Column>()), Times.Once());
            _mockRowRepository.Verify(p => p.Add(It.IsAny<Row>()), Times.Once());
            Assert.That(wasRaised, Is.True);
            AppEvents.ClearHandlers();
        }

        [Test]
        public void TestHandleCsvFilePathChangedEventShouldRaiseFilePathChangedEvent()
        {
            var wasRaised = false;
            _service.FilePathChanged += (sender, args) => { wasRaised = true; };
            _service.Handle(new CsvFilePathChangedEvent());
            Assert.That(wasRaised, Is.True);
        }

        [Test]
        public void TestHandleCsvFileImportedEventShouldRaiseDataImportedEvent()
        {
            var wasRaised = false;
            _service.DataImported += (sender, args) => { wasRaised = true; };
            _service.Handle(new CsvFileImportedEvent());
            Assert.That(wasRaised, Is.True);
        }
    }
}

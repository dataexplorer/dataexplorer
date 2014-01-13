using System.Collections.Generic;
using System.Data;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Importers.CsvFiles.Commands;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Converters;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Sources;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Importers.CsvFile.Commands
{
    [TestFixture]
    public class ImportCsvFileSourceCommandHandlerTests
    {
        private ImportCsvFileSourceCommandHandler _handler;
        private Mock<ICsvFileDataAdapter> _mockDataAdapter;
        private Mock<IDataTypeConverterFactory> _mockFactory;
        private Mock<ISourceRepository> _mockRepository;
        private Mock<IRowRepository> _mockRowRepository;
        private Mock<IColumnRepository> _mockColumnRepository;
        private Mock<IDataContext> _mockDataContext;
        private Mock<IEventBus> _mockEventBus;
        private CsvFileSource _source;
        private DataColumn _column;
        private List<DataColumn> _columns;
        private DataTable _dataTable;
        private List<Row> _value;

        [SetUp]
        public void SetUp()
        {
            _column = new DataColumn("Column 1", typeof(string));
            _columns = new List<DataColumn> { _column };
            _dataTable = new DataTable();
            _value = new List<Row>();
            _dataTable.Columns.Add(_column);
            _dataTable.Rows.Add("Row 1");
            _source = new CsvFileSource();

            _mockDataAdapter = new Mock<ICsvFileDataAdapter>();
            _mockDataAdapter.Setup(p => p.GetDataColumns(_source)).Returns(_columns);
            _mockDataAdapter.Setup(p => p.GetDataTable(_source)).Returns(_dataTable);

            _mockFactory = new Mock<IDataTypeConverterFactory>();
            _mockFactory.Setup(p => p.Create(typeof(string), typeof(string))).Returns(new PassThroughConverter());

            _mockRepository = new Mock<ISourceRepository>();
            _mockRepository.Setup(p => p.GetSource<CsvFileSource>()).Returns(_source);

            _mockRowRepository = new Mock<IRowRepository>();
            _mockRowRepository.Setup(p => p.GetAll()).Returns(_value);
            _mockRowRepository.Setup(p => p.Add(It.IsAny<Row>())).Callback<Row>(p => _value.Add(p));

            _mockColumnRepository = new Mock<IColumnRepository>();
            
            _mockDataContext = new Mock<IDataContext>();

            _mockEventBus = new Mock<IEventBus>();

            _handler = new ImportCsvFileSourceCommandHandler(
                _mockRepository.Object,
                _mockDataAdapter.Object,
                _mockFactory.Object,
                _mockRowRepository.Object,
                _mockColumnRepository.Object,
                _mockDataContext.Object,
                _mockEventBus.Object);
        }
        
        [Test]
        public void TestExecuteShouldRaiseImportingEvent()
        {
            _handler.Execute(new ImportCsvFileSourceCommand());
            _mockEventBus.Verify(p => p.Raise(It.IsAny<CsvFileImportingEvent>()));
        }

        [Test]
        public void TestExecuteShouldClearDataContext()
        {
            _handler.Execute(new ImportCsvFileSourceCommand());
            _mockDataContext.Verify(p => p.Clear(), Times.Once());
        }

        [Test]
        public void TestExecuteShouldSetSource()
        {
            _handler.Execute(new ImportCsvFileSourceCommand());
            _mockRepository.Verify(p => p.SetSource(_source), Times.Once());
        }

        [Test]
        public void TestExecuteShouldAddColumnsToRepository()
        {
            _handler.Execute(new ImportCsvFileSourceCommand());
            _mockColumnRepository.Verify(p => p.Add(It.IsAny<Column>()), Times.Once());
        }

        [Test]
        public void TestExecuteShouldAddRowsToTheRepository()
        {
            _handler.Execute(new ImportCsvFileSourceCommand());
            _mockRowRepository.Verify(p => p.Add(It.IsAny<Row>()), Times.Once());
        }

        [Test]
        public void TestExecuteShouldRaiseProgressChangedEvent()
        {
            _handler.Execute(new ImportCsvFileSourceCommand());
            _mockEventBus.Verify(p => p.Raise(It.IsAny<CsvFileImportProgressChangedEvent>()));
        }

        [Test]
        public void TestExecuteShouldRaiseImportedEvent()
        {
            _handler.Execute(new ImportCsvFileSourceCommand());
            _mockEventBus.Verify(p => p.Raise(It.IsAny<CsvFileImportedEvent>()));
        }
    }
}

using System.Collections.Generic;
using System.Data;
using DataExplorer.Application.Application;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Importers;
using DataExplorer.Application.Importers.CsvFiles;
using DataExplorer.Application.Importers.CsvFiles.Commands;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Application.Rows;
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
        private Mock<ISourceRepository> _mockSourceRepository;
        private Mock<IApplicationStateService> _mockStateService;
        private Mock<IEventBus> _mockEventBus;
        private Mock<IDataContext> _mockDataContext;
        private Mock<ICsvFileDataAdapter> _mockDataAdapter;
        private Mock<IDataTypeConverterFactory> _mockFactory;
        private Mock<IRowRepository> _mockRowRepository;
        private Mock<IColumnRepository> _mockColumnRepository;
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

            _mockSourceRepository = new Mock<ISourceRepository>();
            _mockSourceRepository.Setup(p => p.GetSource<CsvFileSource>()).Returns(_source);

            _mockEventBus = new Mock<IEventBus>();

            _mockStateService = new Mock<IApplicationStateService>();

            _mockDataContext = new Mock<IDataContext>();
            
            _mockDataAdapter = new Mock<ICsvFileDataAdapter>();
            _mockDataAdapter.Setup(p => p.GetDataColumns(_source)).Returns(_columns);
            _mockDataAdapter.Setup(p => p.GetDataTable(_source)).Returns(_dataTable);

            _mockFactory = new Mock<IDataTypeConverterFactory>();
            _mockFactory.Setup(p => p.Create(typeof(string), typeof(string))).Returns(new PassThroughConverter());

            _mockRowRepository = new Mock<IRowRepository>();
            _mockRowRepository.Setup(p => p.GetAll()).Returns(_value);
            _mockRowRepository.Setup(p => p.Add(It.IsAny<Row>())).Callback<Row>(p => _value.Add(p));

            _mockColumnRepository = new Mock<IColumnRepository>();
            
            _handler = new ImportCsvFileSourceCommandHandler(
                _mockSourceRepository.Object,
                _mockEventBus.Object,
                _mockStateService.Object,
                _mockDataContext.Object,
                _mockDataAdapter.Object,
                _mockFactory.Object,
                _mockRowRepository.Object,
                _mockColumnRepository.Object);
        }

        [Test]
        public void TestExecuteShouldRaiseProjectClosingEvent()
        {
            _handler.Execute(new ImportCsvFileSourceCommand());
            _mockEventBus.Verify(p => p.Raise(It.IsAny<ProjectClosingEvent>()));
        }

        [Test]
        public void TestExecuteShouldClearSelectedFilter()
        {
            _handler.Execute(new ImportCsvFileSourceCommand());
            _mockStateService.Verify(p => p.ClearSelectedFilter(), Times.Once());
        }

        [Test]
        public void TestExecuteShouldClearSelectedRows()
        {
            _handler.Execute(new ImportCsvFileSourceCommand());
            _mockStateService.Verify(p => p.ClearSelectedRows(), Times.Once());
        }

        [Test]
        public void TestExecuteShouldClearDataContext()
        {
            _handler.Execute(new ImportCsvFileSourceCommand());
            _mockDataContext.Verify(p => p.Clear(), Times.Once());
        }

        [Test]
        public void TestExecuteShouldRaiseProjectClosedEvent()
        {
            _handler.Execute(new ImportCsvFileSourceCommand());
            _mockEventBus.Verify(p => p.Raise(It.IsAny<ProjectClosedEvent>()));
        }

        [Test]
        public void TestExecuteShouldRaiseSourceImportingEvent()
        {
            _handler.Execute(new ImportCsvFileSourceCommand());
            _mockEventBus.Verify(p => p.Raise(It.IsAny<SourceImportingEvent>()));
        }

        [Test]
        public void TestExecuteShouldSetSource()
        {
            _handler.Execute(new ImportCsvFileSourceCommand());
            _mockSourceRepository.Verify(p => p.SetSource(_source), Times.Once());
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
            _mockEventBus.Verify(p => p.Raise(It.IsAny<SourceImportProgressChangedEvent>()));
        }

        [Test]
        public void TestExecuteShouldRaiseSourceImportedEvent()
        {
            _handler.Execute(new ImportCsvFileSourceCommand());
            _mockEventBus.Verify(p => p.Raise(It.IsAny<SourceImportedEvent>()));
        }
    }
}

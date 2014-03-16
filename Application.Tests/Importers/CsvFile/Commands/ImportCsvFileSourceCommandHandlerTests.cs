using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Media.Imaging;
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
using DataExplorer.Domain.DataTypes.Converters;
using DataExplorer.Domain.DataTypes.Loaders;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Semantics;
using DataExplorer.Domain.Sources;
using DataExplorer.Domain.Sources.Maps;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Tests.Sources.Maps;
using DataExplorer.Infrastructure.Tests.Importers;
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
        private Mock<IDataTypeConverterFactory> _mockConverterFactory;
        private Mock<IDataLoaderFactory> _mockLoaderFactory;
        private Mock<IColumnFactory> _mockColumnFactory;
        private Mock<IColumnRepository> _mockColumnRepository;
        private Mock<IRowRepository> _mockRowRepository;
        private CsvFileSource _source;
        private Column _column;
        private DataTable _dataTable;
        private List<Row> _value;
        private SourceMap _map;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder()
                .WithId(0)
                .WithIndex(1)
                .WithName("Test")
                .WithDataType(typeof (string))
                .WithSemanticType(SemanticType.Measure)
                .Build();
            _dataTable = new DataTableBuilder()
                .WithColumn(new DataColumn())
                .WithRow("Field 1")
                .Build();
            _value = new List<Row>();
            _map = new SourceMapBuilder()
                .WithIndex(_column.Index)
                .WithName(_column.Name)
                .WithDataType(_column.DataType)
                .WithSemanticType(_column.SemanticType)
                .Build();
            _source = new CsvFileSource();
            _source.SetMaps(new List<SourceMap> {_map });

            _mockSourceRepository = new Mock<ISourceRepository>();
            _mockSourceRepository.Setup(p => p.GetSource<CsvFileSource>())
                .Returns(_source);

            _mockEventBus = new Mock<IEventBus>();

            _mockStateService = new Mock<IApplicationStateService>();

            _mockDataContext = new Mock<IDataContext>();
            
            _mockDataAdapter = new Mock<ICsvFileDataAdapter>();
            _mockDataAdapter.Setup(p => p.GetTable(_source))
                .Returns(_dataTable);

            _mockConverterFactory = new Mock<IDataTypeConverterFactory>();
            _mockConverterFactory.Setup(p => p.Create(typeof(string), _column.DataType))
                .Returns(new PassThroughConverter());

            _mockLoaderFactory = new Mock<IDataLoaderFactory>();
            _mockLoaderFactory.Setup(p => p.Create(_column.DataType, _source.FilePath))
                .Returns(new FakeDataLoader());
            
            _mockColumnFactory = new Mock<IColumnFactory>();
            _mockColumnFactory.Setup(p => p.Create(_column.Index + 1, _column.Index, _column.Name, _column.DataType, _column.SemanticType, It.IsAny<List<object>>()))
                .Returns(_column);
            
            _mockColumnRepository = new Mock<IColumnRepository>();

            _mockRowRepository = new Mock<IRowRepository>();
            _mockRowRepository.Setup(p => p.GetAll())
                .Returns(_value);
            _mockRowRepository.Setup(p => p.Add(It.IsAny<Row>()))
                .Callback<Row>(p => _value.Add(p));
            
            _handler = new ImportCsvFileSourceCommandHandler(
                _mockSourceRepository.Object,
                _mockEventBus.Object,
                _mockStateService.Object,
                _mockDataContext.Object,
                _mockDataAdapter.Object,
                _mockConverterFactory.Object,
                _mockLoaderFactory.Object,
                _mockColumnFactory.Object,
                _mockColumnRepository.Object,
                _mockRowRepository.Object);
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
        public void TestExecuteWithDataLoaderShouldLoadData()
        {
            _handler.Execute(new ImportCsvFileSourceCommand());
            _mockRowRepository.Verify(p => p.Add(It.Is<Row>(q => q[0] is BitmapImage)));
        }

        [Test]
        public void TestExecuteWithoutDataLoaderShouldNotLoadData()
        {
            _mockLoaderFactory.Setup(p => p.Create(_column.DataType, _source.FilePath))
                .Returns((IDataLoader) null);
            _handler.Execute(new ImportCsvFileSourceCommand());
            _mockRowRepository.Verify(p => p.Add(It.Is<Row>(q => q[0] is string)));
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

    public class FakeDataLoader : IDataLoader
    {
        public object Load(string uri)
        {
            return new BitmapImage();
        }
    }
}

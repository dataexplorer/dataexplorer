using System;
using System.Collections.Generic;
using System.Data;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Importers;
using DataExplorer.Application.Importers.CsvFiles;
using DataExplorer.Application.Importers.CsvFiles.Commands;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Domain.DataTypes.Detectors;
using DataExplorer.Domain.Semantics;
using DataExplorer.Domain.Sources;
using DataExplorer.Domain.Sources.Maps;
using DataExplorer.Infrastructure.Tests.Importers;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Importers.CsvFile.Commands
{
    [TestFixture]
    public class UpdateCsvFileSourceCommandHandlerTests
    {
        private UpdateCsvFileSourceCommandHandler _handler;
        private Mock<ISourceRepository> _mockRepository;
        private Mock<ICsvFileDataAdapter> _mockDataAdapter;
        private Mock<IDataTypeDetector> _mockDataTypeDetector;
        private Mock<ISemanticTypeDetector> _mockSemanticTypeDetector;
        private Mock<ISourceMapFactory> _mockFactory;
        private Mock<IEventBus> _mockEventBus;
        private CsvFileSource _source;
        private DataTable _table;
        private DataColumn _dataColumn;
        private SourceMap _map;
        private string _filePath;
        private Type _dataType;
        private SemanticType _semanticType;

        [SetUp]
        public void SetUp()
        {
            _semanticType = SemanticType.Measure;
            _dataType = typeof (Boolean);
            _filePath = @"C:\Test.csv";
            _map = new SourceMap();
            _dataColumn = new DataColumnBuilder()
                .WithColumnName("Test")
                .WithDataType(typeof(Boolean))
                .Build();
            _table = new DataTableBuilder()
                .WithColumn(_dataColumn)
                .Build();
            _source = new CsvFileSource();
            
            _mockRepository = new Mock<ISourceRepository>();
            _mockRepository.Setup(p => p.GetSource<CsvFileSource>())
                .Returns(_source);

            _mockDataAdapter = new Mock<ICsvFileDataAdapter>();
            _mockDataAdapter.Setup(p => p.GetTable(_source))
                .Returns(_table);

            _mockDataTypeDetector = new Mock<IDataTypeDetector>();
            _mockDataTypeDetector.Setup(p => p.Detect(It.IsAny<IEnumerable<object>>()))
                .Returns(_dataType);

            _mockSemanticTypeDetector = new Mock<ISemanticTypeDetector>();
            _mockSemanticTypeDetector.Setup(p => p.Detect(_dataType, It.IsAny<List<object>>()))
                .Returns(_semanticType);

            _mockFactory = new Mock<ISourceMapFactory>();
            _mockFactory.Setup(p => p.Create(_dataColumn.Ordinal, _dataColumn.ColumnName, _dataType, _semanticType))
                .Returns(_map);

            _mockEventBus = new Mock<IEventBus>();

            _handler = new UpdateCsvFileSourceCommandHandler(
                _mockRepository.Object,
                _mockDataAdapter.Object,
                _mockDataTypeDetector.Object,
                _mockSemanticTypeDetector.Object,
                _mockFactory.Object,
                _mockEventBus.Object);
        }

        [Test]
        public void TestUpdateSourceShouldUpdateSourceFilePath()
        {
            _handler.Execute(new UpdateCsvFileSourceCommand(_filePath));
            Assert.That(_source.FilePath, Is.EqualTo(_filePath));
        }

        [Test]
        public void TestExecuteShouldUpdateSourceMaps()
        {
            _handler.Execute(new UpdateCsvFileSourceCommand(_filePath));
            Assert.That(_source.GetMaps(), Has.Member(_map));
        }

        [Test]
        public void TestExecuteShouldRaiseSourceChangedEvent()
        {
            _handler.Execute(new UpdateCsvFileSourceCommand(_filePath));
            _mockEventBus.Verify(p => p.Raise(It.IsAny<CsvFileSourceChangedEvent>()));
        }
    }
}

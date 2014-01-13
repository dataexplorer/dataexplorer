using System.Collections.Generic;
using System.Data;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Importers.CsvFiles.Commands;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Domain.Sources;
using DataExplorer.Domain.Sources.Maps;
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
        private Mock<ISourceMapFactory> _mockFactory;
        private Mock<IEventBus> _mockEventBus;
        private CsvFileSource _source;
        private List<DataColumn> _dataColumns;
        private DataColumn _dataColumn;
        private List<SourceMap> _maps; 
        private SourceMap _map;
        private string _filePath;

        [SetUp]
        public void SetUp()
        {
            _filePath = @"C:\Test.csv";
            _map = new SourceMap();
            _maps = new List<SourceMap> { _map };
            _dataColumn = new DataColumn();
            _dataColumns = new List<DataColumn> { _dataColumn };
            _source = new CsvFileSource();
            
            _mockRepository = new Mock<ISourceRepository>();
            _mockRepository.Setup(p => p.GetSource<CsvFileSource>()).Returns(_source);

            _mockDataAdapter = new Mock<ICsvFileDataAdapter>();
            _mockDataAdapter.Setup(p => p.GetDataColumns(_source)).Returns(_dataColumns);

            _mockFactory = new Mock<ISourceMapFactory>();
            _mockFactory.Setup(p => p.Create(_dataColumn)).Returns(_map);

            _mockEventBus = new Mock<IEventBus>();

            _handler = new UpdateCsvFileSourceCommandHandler(
                _mockRepository.Object,
                _mockDataAdapter.Object,
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
            Assert.That(_source.GetMaps(), Is.EqualTo(_maps));
        }

        [Test]
        public void TestExecuteShouldRaiseSourceChangedEvent()
        {
            _handler.Execute(new UpdateCsvFileSourceCommand(_filePath));
            _mockEventBus.Verify(p => p.Raise(It.IsAny<CsvFileSourceChangedEvent>()));
        }
    }
}

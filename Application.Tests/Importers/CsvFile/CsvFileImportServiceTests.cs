using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Importers;
using DataExplorer.Application.Importers.CsvFiles;
using DataExplorer.Application.Importers.CsvFiles.Commands;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Importers.CsvFiles.Queries;
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
        private Mock<IGetCsvFileSourceQuery> _mockGetSourceQuery;
        private Mock<IUpdateCsvFileSourceCommand> _mockUpdateCommand;
        private Mock<IGetCsvFileSourceMapsQuery> _mockGetMapsQuery;
        private Mock<ICanImportQuery> _mockCanImportQuery;
        private Mock<IImportCsvFileSourceCommand> _mockImportCommand;

        [SetUp]
        public void SetUp()
        {
            _mockGetSourceQuery = new Mock<IGetCsvFileSourceQuery>();
            _mockUpdateCommand = new Mock<IUpdateCsvFileSourceCommand>();
            _mockGetMapsQuery = new Mock<IGetCsvFileSourceMapsQuery>();
            _mockCanImportQuery = new Mock<ICanImportQuery>();
            _mockImportCommand = new Mock<IImportCsvFileSourceCommand>();

            _service = new CsvFileImportService(
                _mockGetSourceQuery.Object,
                _mockUpdateCommand.Object,
                _mockGetMapsQuery.Object,
                _mockCanImportQuery.Object,
                _mockImportCommand.Object);
        }

        [Test]
        public void TestGetSourceShouldReturnQueryResult()
        {
            var sourceDto = new CsvFileSourceDto();
            _mockGetSourceQuery.Setup(p => p.Query()).Returns(sourceDto);
            var result = _service.GetSource();
            Assert.That(result, Is.EqualTo(sourceDto));
        }

        [Test]
        public void TestUpdateSourceShouldExecuteCommand()
        {
            var filePath = @"C:\Test.csv";
            _service.UpdateSource(filePath);
            _mockUpdateCommand.Verify(p => p.Execute(filePath), Times.Once());
        }

        [Test]
        public void TestGetSourceMapsShouldReturnQueryResults()
        {
            var map = new SourceMap();
            var maps = new List<SourceMap> { map };
            _mockGetMapsQuery.Setup(p => p.Query()).Returns(maps);
            var result = _service.GetMaps();
            Assert.That(result, Is.EqualTo(maps));
        }

        [Test]
        public void TestCanImportShouldReturnQueryResult()
        {
            _mockCanImportQuery.Setup(p => p.Query()).Returns(true);
            var result = _service.CanImport();
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestImportShouldExecuteCommand()
        {
            _service.Import();
            _mockImportCommand.Verify(p => p.Execute(), Times.Once());
        }
    }
}

using System.Collections.Generic;
using DataExplorer.Application.Importers.CsvFiles.Queries;
using DataExplorer.Domain.Sources;
using DataExplorer.Domain.Sources.Maps;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Importers.CsvFile.Queries
{
    [TestFixture]
    public class GetCsvFileSourceMapsQueryTests
    {
        private GetCsvFileSourceMapsQuery _query;
        private Mock<ISourceRepository> _mockRepository;
        private CsvFileSource _source;
        private SourceMap _map;
        private List<SourceMap> _maps;
        
        [SetUp]
        public void SetUp()
        {
            _map = new SourceMap();
            _maps = new List<SourceMap> { _map };
            _source = new CsvFileSource();

            _mockRepository = new Mock<ISourceRepository>();
            _mockRepository.Setup(p => p.GetSource<CsvFileSource>()).Returns(_source);

            _query = new GetCsvFileSourceMapsQuery(_mockRepository.Object);
        }

        [Test]
        public void TestGetMapsShouldReturnMaps()
        {
            _source.SetMaps(_maps);
            var result = _query.Query();
            Assert.That(result, Contains.Item(_map));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Importers.CsvFiles;
using DataExplorer.Application.Importers.CsvFiles.Queries;
using DataExplorer.Domain.Sources;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Importers.CsvFile.Queries
{
    [TestFixture]
    public class GetCsvFileSourceQueryTests
    {
        private GetCsvFileSourceQuery _query;
        private Mock<ISourceRepository> _mockRepository;
        private Mock<ICsvFileSourceAdapter> _mockAdapter;
        private CsvFileSource _source;
        private CsvFileSourceDto _sourceDto;

        [SetUp]
        public void SetUp()
        {
            _source = new CsvFileSource();
            _sourceDto = new CsvFileSourceDto();
            
            _mockAdapter = new Mock<ICsvFileSourceAdapter>();
            _mockAdapter.Setup(p => p.Adapt(_source)).Returns(_sourceDto);
            
            _mockRepository = new Mock<ISourceRepository>();
            _mockRepository.Setup(p => p.GetSource<CsvFileSource>()).Returns(_source);

            _query = new GetCsvFileSourceQuery(
                _mockRepository.Object, 
                _mockAdapter.Object);
        }

        [Test]
        public void TestQueryShouldReturnSourceDto()
        {
            _sourceDto.FilePath = @"C:\Test.xml";
            var result = _query.Query();
            Assert.That(result.FilePath, Is.EqualTo(@"C:\Test.xml"));
        }
    }
}

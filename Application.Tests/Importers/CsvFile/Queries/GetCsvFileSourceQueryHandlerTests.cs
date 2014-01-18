using DataExplorer.Application.Importers;
using DataExplorer.Application.Importers.CsvFiles;
using DataExplorer.Application.Importers.CsvFiles.Queries;
using DataExplorer.Domain.Sources;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Importers.CsvFile.Queries
{
    [TestFixture]
    public class GetCsvFileSourceQueryHandlerTests
    {
        private GetCsvFileSourceQueryHandler _handler;
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

            _handler = new GetCsvFileSourceQueryHandler(
                _mockRepository.Object, 
                _mockAdapter.Object);
        }

        [Test]
        public void TestQueryShouldReturnSourceDto()
        {
            _sourceDto.FilePath = @"C:\Test.xml";
            var result = _handler.Execute(new GetCsvFileSourceQuery());
            Assert.That(result.FilePath, Is.EqualTo(@"C:\Test.xml"));
        }
    }
}

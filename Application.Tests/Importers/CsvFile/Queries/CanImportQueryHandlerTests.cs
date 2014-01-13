using DataExplorer.Application.Importers.CsvFiles.Queries;
using DataExplorer.Domain.Sources;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Importers.CsvFile.Queries
{
    [TestFixture]
    public class CanImportQueryHandlerTests
    {
        private CanImportQueryHandler _handler;
        private Mock<ISourceRepository> _mockRepository;
        private CsvFileSource _source;

        [SetUp]
        public void SetUp()
        {
            _source = new CsvFileSource();

            _mockRepository = new Mock<ISourceRepository>();
            _mockRepository.Setup(p => p.GetSource<CsvFileSource>()).Returns(_source);
            
            _handler = new CanImportQueryHandler(_mockRepository.Object);
        }

        [Test]
        public void TestCanImportShouldReturnTrueIfFilePathExists()
        {
            _source.FilePath = @"C:\Test.csv";
            var result = _handler.Execute(new CanImportQuery());
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestCanImportShouldReturnFalseIfFilePathIsNull()
        {
            _source.FilePath = null;
            _mockRepository.Setup(p => p.GetSource<CsvFileSource>()).Returns(_source);
            var result = _handler.Execute(new CanImportQuery());
            Assert.That(result, Is.False);
        }

        [Test]
        public void TestCanImportShouldReturnFalseIfFilePathIsEmpty()
        {
            _source.FilePath = string.Empty;
            _mockRepository.Setup(p => p.GetSource<CsvFileSource>()).Returns(_source);
            var result = _handler.Execute(new CanImportQuery());
            Assert.That(result, Is.False);
        }
    }
}

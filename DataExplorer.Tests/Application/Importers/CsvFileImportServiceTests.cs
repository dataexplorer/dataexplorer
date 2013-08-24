using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Importers.CsvFile;
using DataExplorer.Domain.Sources;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Importers
{
    [TestFixture]
    public class CsvFileImportServiceTests
    {
        private CsvFileImportService _service;
        private Mock<ISourceFactory> _mockFactory;
        private Mock<ISourceRepository> _mockRepository;
        private CsvFileSource _source;

        [SetUp]
        public void SetUp()
        {
            _source = new CsvFileSource();
            _mockFactory = new Mock<ISourceFactory>();
            _mockRepository = new Mock<ISourceRepository>();
            _service = new CsvFileImportService(_mockFactory.Object, _mockRepository.Object);
        }

        [Test]
        public void TestGetFilePathShouldReturnFilePath()
        {
            _source.FilePath = @"C:\Test.xml";
            _mockRepository.Setup(p => p.HasSource<CsvFileSource>()).Returns(true);
            _mockRepository.Setup(p => p.GetSource<CsvFileSource>()).Returns(_source);
            var result = _service.GetFilePath();
            Assert.That(result, Is.EqualTo(@"C:\Test.xml"));
        }

        [Test]
        public void TestGetFilePathShouldCreateSourceIfItDoesNotExist()
        {
            _source.FilePath = @"C:\Test.xml";
            _mockRepository.Setup(p => p.HasSource<CsvFileSource>()).Returns(false);
            _mockRepository.Setup(p => p.GetSource<CsvFileSource>()).Returns(_source);
            _mockFactory.Setup(p => p.Create<CsvFileSource>()).Returns(_source);
            _service.GetFilePath();
            _mockRepository.Verify(p => p.SetSource(_source), Times.Once());
        }

        [Test]
        public void TestSetFilePathShouldSetFilePathOfImporter()
        {
            _mockRepository.Setup(p => p.GetSource<CsvFileSource>()).Returns(_source);
            _service.SetFilePath(@"C:\Test.csv");
            Assert.That(_source.FilePath, Is.EqualTo(@"C:\Test.csv"));
        }

        [Test]
        public void TestHandleCsvFilePathChangedEventShouldRaiseFilePathChangedEvent()
        {
            var wasRaised = false;
            _service.FilePathChanged += (sender, args) => { wasRaised = true; };
            _service.Handle(new CsvFilePathChangedEvent());
            Assert.That(wasRaised, Is.True);
        }
    }
}

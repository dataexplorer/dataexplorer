using System;
using System.Collections.Generic;
using System.Linq;
using DataExplorer.Application.Importers;
using DataExplorer.Application.Importers.CsvFile;
using DataExplorer.Domain.Sources;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Importers.CsvFile
{
    [TestFixture]
    public class CsvFileAdapterTests
    {
        private CsvFileDataAdapter _dataAdapter;
        private Mock<ICsvFile> _mockFile;
        private Mock<ICsvFileParser> _mockParser;
        private Mock<IDataTypeDetector> _mockDetector;
        private CsvFileSource _source;

        [SetUp]
        public void SetUp()
        {
            _source = new CsvFileSource();
            _mockFile = new Mock<ICsvFile>();
            _mockParser = new Mock<ICsvFileParser>();
            _mockDetector = new Mock<IDataTypeDetector>();
            _dataAdapter = new CsvFileDataAdapter(
                _mockFile.Object,
                _mockParser.Object,
                _mockDetector.Object);
        }

        [Test]
        public void TestExistsShouldReturnIfCsvFileExists()
        {
            var filePath = @"C:\Test.csv";
            _source.FilePath = filePath;
            _mockFile.Setup(p => p.Exists(filePath)).Returns(true);
            var result = _dataAdapter.Exists(_source);
            Assert.That(result, Is.True);
        }

        [Test]
        public void GetDataColumnsShouldReturnDataColumnsFromCsvFile()
        {
            _source.FilePath = @"C:\Test.csv";
            var columns = new string[] { "Column 1"};
            var fields = new string[] { "Field 1" };
            _mockParser.SetupSequence(p => p.ReadFields()).Returns(columns).Returns(fields);
            _mockParser.SetupSequence(p => p.IsEndOfFile()).Returns(false).Returns(true);
            _mockDetector.Setup(p => p.Detect(It.Is<List<string>>(q => q.Contains(fields[0])))).Returns(typeof(String));
            var result = _dataAdapter.GetDataColumns(_source);
            _mockParser.Verify(p => p.OpenFile(@"C:\Test.csv"), Times.Once());
            _mockParser.Verify(p => p.CloseFile(), Times.Once());
            Assert.That(result.Single().ColumnName, Is.EqualTo("Column 1"));
            Assert.That(result.Single().DataType, Is.EqualTo(typeof(String)));
        }

        [Test]
        public void GetDataTableShouldReturnDataTableFromCsvFile()
        {
            _source.FilePath = @"C:\Test.csv";
            var columns = new string[] { "Column 1" };
            var fields = new string[] { "Field 1" };
            _mockParser.SetupSequence(p => p.ReadFields()).Returns(columns).Returns(fields);
            _mockParser.SetupSequence(p => p.IsEndOfFile()).Returns(false).Returns(true);
            _mockDetector.Setup(p => p.Detect(It.Is<List<string>>(q => q.Contains(fields[0])))).Returns(typeof(String));
            var result = _dataAdapter.GetDataTable(_source);
            _mockParser.Verify(p => p.OpenFile(@"C:\Test.csv"), Times.Once());
            _mockParser.Verify(p => p.CloseFile(), Times.Once());
            Assert.That(result.Columns[0].ColumnName, Is.EqualTo("Column 1"));
            Assert.That(result.Columns[0].DataType, Is.EqualTo(typeof(String)));
            Assert.That(result.Rows[0][0], Is.EqualTo("Field 1"));
        }
    }
}

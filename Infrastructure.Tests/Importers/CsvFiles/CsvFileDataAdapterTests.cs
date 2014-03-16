using System;
using System.Collections.Generic;
using System.Linq;
using DataExplorer.Domain.DataTypes.Detectors;
using DataExplorer.Domain.Semantics;
using DataExplorer.Domain.Sources;
using DataExplorer.Infrastructure.Importers.CsvFile;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Infrastructure.Tests.Importers.CsvFiles
{
    [TestFixture]
    public class CsvFileDataAdapterTests
    {
        private CsvFileDataAdapter _dataAdapter;
        private Mock<ICsvFile> _mockFile;
        private Mock<ICsvFileParser> _mockParser;
        private Mock<IDataTypeDetector> _mockDataTypeDetector;
        private Mock<ISemanticTypeDetector> _mockSemanticTypeDetector;
        private CsvFileSource _source;
        private string _filePath;

        [SetUp]
        public void SetUp()
        {
            _filePath = @"C:\Test.csv";
            _source = new CsvFileSource { FilePath = _filePath };
            
            _mockFile = new Mock<ICsvFile>();
            
            _mockParser = new Mock<ICsvFileParser>();
            _mockParser.SetupSequence(p => p.ReadFields())
                .Returns(new string[] { "Column 1" })
                .Returns(new string[] { "Field 1" });
            _mockParser.SetupSequence(p => p.IsEndOfFile())
                .Returns(false)
                .Returns(true);

            _mockDataTypeDetector = new Mock<IDataTypeDetector>();
            _mockDataTypeDetector.Setup(p => p.Detect(
                It.Is<List<object>>(q => q.Contains("Field 1"))))
                .Returns(typeof(String));

            _mockSemanticTypeDetector = new Mock<ISemanticTypeDetector>();
            _mockSemanticTypeDetector.Setup(p => p.Detect(typeof(string), It.IsAny<List<object>>()))
                .Returns(SemanticType.Measure);

            _dataAdapter = new CsvFileDataAdapter(
                _mockFile.Object,
                _mockParser.Object,
                _mockDataTypeDetector.Object);
        }

        [Test]
        public void TestExistsShouldReturnIfCsvFileExists()
        {
            _mockFile.Setup(p => p.Exists(_filePath)).Returns(true);
            var result = _dataAdapter.Exists(_source);
            Assert.That(result, Is.True);
        }

        [Test]
        public void GetDataColumnsShouldReturnDataColumnsFromCsvFile()
        {
           var result = _dataAdapter.GetColumns(_source);
            _mockParser.Verify(p => p.OpenFile(@"C:\Test.csv"), Times.Once());
            _mockParser.Verify(p => p.CloseFile(), Times.Once());
            Assert.That(result.Single().ColumnName, Is.EqualTo("Column 1"));
            Assert.That(result.Single().DataType, Is.EqualTo(typeof(String)));
        }

        [Test]
        public void GetDataTableShouldReturnDataTableFromCsvFile()
        {
            var result = _dataAdapter.GetTable(_source);
            _mockParser.Verify(p => p.OpenFile(@"C:\Test.csv"), Times.Once());
            _mockParser.Verify(p => p.CloseFile(), Times.Once());
            Assert.That(result.Columns[0].ColumnName, Is.EqualTo("Column 1"));
            Assert.That(result.Columns[0].DataType, Is.EqualTo(typeof(String)));
            Assert.That(result.Rows[0][0], Is.EqualTo("Field 1"));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Sources;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.Importers
{
    [TestFixture]
    public class CsvFileSourceTests
    {
        private CsvFileSource _source;

        [SetUp]
        public void SetUp()
        {
            _source = new CsvFileSource();
        }

        [Test]
        public void TestGetSetFilePathShouldGetSetFilePath()
        {
            _source.FilePath = @"C:\Test.csv";
            Assert.That(_source.FilePath, Is.EqualTo(@"C:\Test.csv"));
        }
    }
}

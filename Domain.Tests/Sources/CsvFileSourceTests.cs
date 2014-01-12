using System.Collections.Generic;
using DataExplorer.Domain.Sources;
using DataExplorer.Domain.Sources.Maps;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.Sources
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

        [Test]
        public void TestGetSetMapsShouldGetSetMaps()
        {
            var map = new SourceMap();
            var maps = new List<SourceMap> { map };
            _source.SetMaps(maps);
            var result = _source.GetMaps();
            Assert.That(result, Contains.Item(map));
        }
    }
}

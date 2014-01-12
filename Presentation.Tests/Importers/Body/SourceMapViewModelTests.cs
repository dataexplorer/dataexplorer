using System;
using DataExplorer.Domain.Sources.Maps;
using DataExplorer.Presentation.Importers.CsvFile.Body;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Importers.Body
{
    [TestFixture]
    public class SourceMapViewModelTests
    {
        private SourceMapViewModel _viewModel;
        private SourceMap _map;

        [SetUp]
        public void SetUp()
        {
            _map = new SourceMap();
            _viewModel = new SourceMapViewModel(_map);
        }

        [Test]
        public void TestNameShouldReturnMapName()
        {
            _map.Name = "Test";
            var result = _viewModel.Name;
            Assert.That(result, Is.EqualTo("Test"));
        }

        [Test]
        public void TestSourcTypeShouldReturnSourceType()
        {
            _map.SourceType = typeof(String);
            var result = _viewModel.SourceType;
            Assert.That(result, Is.EqualTo("String"));
        }
    }
}

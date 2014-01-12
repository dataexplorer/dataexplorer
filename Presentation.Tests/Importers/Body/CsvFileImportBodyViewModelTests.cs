using System.Collections.Generic;
using System.Linq;
using DataExplorer.Application.Importers.CsvFiles;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Domain.Sources.Maps;
using DataExplorer.Presentation.Importers.CsvFile.Body;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Importers.Body
{
    [TestFixture]
    public class CsvFileImportBodyViewModelTests
    {
        private CsvFileImportBodyViewModel _viewModel;
        private Mock<ICsvFileImportService> _mockService;

        [SetUp]
        public void SetUp()
        {
            _mockService = new Mock<ICsvFileImportService>();
            _viewModel = new CsvFileImportBodyViewModel(_mockService.Object);
        }

        [Test]
        public void TestGetMapViewModelsShouldGetMapViewModelsFromService()
        {
            var map = new SourceMap();
            var maps = new List<SourceMap> { map };
            _mockService.Setup(p => p.GetMaps()).Returns(maps);
            Assert.That(_viewModel.MapViewModels.Any(p => p.Map == map));
        }

        [Test]
        public void TestHandleShouldNotifyUpdateOfMapViewModels()
        {
            var wasRaised = false;
            _viewModel.PropertyChanged += (s, e) => { wasRaised = e.PropertyName == "MapViewModels"; };
            _viewModel.Handle(new CsvFileSourceChangedEvent());
            Assert.That(wasRaised, Is.True);
        }
    }
}

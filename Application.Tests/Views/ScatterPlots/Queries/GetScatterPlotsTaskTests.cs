using System.Collections.Generic;
using System.Linq;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Application.Views.ScatterPlots.Queries;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Views.ScatterPlots.Queries
{
    [TestFixture]
    public class GetScatterPlotsQueryTests
    {
        private GetPlotsQuery _query;
        private Mock<IViewRepository> _mockRepository;
        private Mock<IScatterPlotAdapter> _mockAdapter;
        private ScatterPlot _scatterPlot;
        private List<Plot> _plots;
        private Plot _plot;
        private List<PlotDto> _plotDtos;
        private PlotDto _plotDto;

        [SetUp]
        public void SetUp()
        {
            _plot = new Plot();
            _plots = new List<Plot> { _plot };
            _plotDto = new PlotDto();
            _plotDtos = new List<PlotDto> { _plotDto };
            _scatterPlot = new ScatterPlot();
            _scatterPlot.SetPlots(_plots);
            _mockRepository = new Mock<IViewRepository>();
            _mockRepository.Setup(p => p.Get<ScatterPlot>()).Returns(_scatterPlot);
            _mockAdapter = new Mock<IScatterPlotAdapter>();
            _mockAdapter.Setup(p => p.Adapt(_plots)).Returns(_plotDtos);
            _query = new GetPlotsQuery(
                _mockRepository.Object,
                _mockAdapter.Object);
        }

        [Test]
        public void TestGetPlotsShouldReturnPlots()
        {
            var results = _query.GetPlots();
            Assert.That(results.Single(), Is.EqualTo(_plotDto));
        }
    }
}

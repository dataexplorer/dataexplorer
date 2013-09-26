using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Application.ScatterPlots.Tasks;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.ScatterPlots.Tasks
{
    [TestFixture]
    public class GetScatterPlotsTaskTests
    {
        private GetPlotsTask _task;
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
            _task = new GetPlotsTask(
                _mockRepository.Object,
                _mockAdapter.Object);
        }

        [Test]
        public void TestGetPlotsShouldReturnPlots()
        {
            var results = _task.GetPlots();
            Assert.That(results.Single(), Is.EqualTo(_plotDto));
        }
    }
}

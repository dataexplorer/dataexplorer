using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.ScatterPlot;
using DataExplorer.Domain.Data;
using DataExplorer.Domain.ScatterPlot;
using DataExplorer.Domain.View;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.ScatterPlot
{
    [TestFixture]
    public class ScatterPlotServiceTests
    {
        private ScatterPlotService _service;
        private Mock<IDataRepository> _mockDataRepository;
        private Mock<IViewRepository> _mockViewRepository;
        private Mock<IScatterPlotAdapter> _mockAdapter;
        private Mock<IScatterPlotRenderer> _mockRenderer;
        private Mock<IScatterPlot> _mockScatterPlot;

        [SetUp]
        public void SetUp()
        {
            _mockDataRepository = new Mock<IDataRepository>();
            _mockViewRepository = new Mock<IViewRepository>();
            _mockAdapter = new Mock<IScatterPlotAdapter>();
            _mockRenderer = new Mock<IScatterPlotRenderer>();
            _mockScatterPlot = new Mock<IScatterPlot>();
            _service = new ScatterPlotService(_mockDataRepository.Object, _mockViewRepository.Object, _mockAdapter.Object, _mockRenderer.Object);
        }

        [Test]
        public void TestGetViewExtentShouldGetViewExtent()
        {
            var viewExtent = new Rect();
            _mockViewRepository.Setup(p => p.GetScatterPlot()).Returns(_mockScatterPlot.Object);
            _mockScatterPlot.Setup(p => p.GetViewExtent()).Returns(viewExtent);
            _service.GetViewExtent();
            _mockScatterPlot.Verify(p => p.GetViewExtent(), Times.Once());
        }

        [Test]
        public void TestSetViewExtentShouldSetViewExtent()
        {
            var viewExtent = new Rect();
            _mockViewRepository.Setup(p => p.GetScatterPlot()).Returns(_mockScatterPlot.Object);
            _service.SetViewExtent(viewExtent);
            _mockScatterPlot.Verify(p => p.SetViewExtent(viewExtent), Times.Once());
        }

        [Test]
        public void TestGetShouldReturnScatterPlotToDto()
        {
            var scatterPlot = _mockScatterPlot.Object;
            var plotDtos = new List<PlotDto>();
            _mockDataRepository.Setup(p => p.GetAll()).Returns(new List<DataRow>());
            _mockViewRepository.Setup(p => p.GetScatterPlot()).Returns(scatterPlot);
            _mockAdapter.Setup(p => p.Adapt(scatterPlot.GetPlots())).Returns(plotDtos);
            var result = _service.GetPlots();
            Assert.That(result, Is.EqualTo(plotDtos));
        }

        [Test]
        public void TestUpdateRowsShouldSetPlotsInScatterPlot()
        {
            var rows = new List<DataRow>();
            var plots = new List<Plot>();
            _mockDataRepository.Setup(p => p.GetAll()).Returns(rows);
            _mockViewRepository.Setup(p => p.GetScatterPlot()).Returns(_mockScatterPlot.Object);
            _mockRenderer.Setup(p => p.RenderPlots(rows)).Returns(plots);
            _service.UpdateRows();
            _mockScatterPlot.Verify(p => p.SetPlots(plots), Times.Once());
        }
    }


}

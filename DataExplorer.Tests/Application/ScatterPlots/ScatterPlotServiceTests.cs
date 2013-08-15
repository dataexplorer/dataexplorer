using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotServiceTests
    {
        private ScatterPlotService _service;
        private Mock<IViewRepository> _mockViewRepository;
        private Mock<IScatterPlotAdapter> _mockAdapter;
        private Mock<IScatterPlot> _mockScatterPlot;

        [SetUp]
        public void SetUp()
        {
            _mockViewRepository = new Mock<IViewRepository>();
            _mockAdapter = new Mock<IScatterPlotAdapter>();
            _mockScatterPlot = new Mock<IScatterPlot>();
            _service = new ScatterPlotService( 
                _mockViewRepository.Object, 
                _mockAdapter.Object);
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
            _mockViewRepository.Setup(p => p.GetScatterPlot()).Returns(scatterPlot);
            _mockAdapter.Setup(p => p.Adapt(scatterPlot.GetPlots())).Returns(plotDtos);
            var result = _service.GetPlots();
            Assert.That(result, Is.EqualTo(plotDtos));
        }

        [Test]
        public void TestHandleScatterPlotChangedEventShouldRaiseScatterPlotChangedEvent()
        {
            var args = new ScatterPlotChangedEvent();
            var wasHandled = false;
            _service.ScatterPlotChanged += (source, eventArgs) => { wasHandled = true; };
            _service.Handle(args);
            Assert.That(wasHandled, Is.True);
        }
    }
}

using System.Collections.Generic;
using System.Windows;
using DataExplorer.Application.Filters;
using DataExplorer.Application.Rows;
using DataExplorer.Application.Views;
using DataExplorer.Application.Views.ScatterPlots.Commands;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Views.ScatterPlots.Commands
{
    [TestFixture]
    public class UpdatePlotsCommandHandlerTests
    {
        private UpdatePlotsCommandHandler _handler;
        private Mock<IFilterRepository> _mockFilterRepository;
        private Mock<IRowRepository> _mockDataRepository;
        private Mock<IViewRepository> _mockViewRepository;
        private Mock<IScatterPlotRenderer> _mockRenderer;
        private ScatterPlot _scatterPlot;
        private ScatterPlotLayout _layout;
        private List<Filter> _filters;
        private Column _column;
        private List<Row> _rows;
        private List<Plot> _plots;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().Build();
            _filters = new List<Filter>();
            _rows = new List<Row>();
            _plots = new List<Plot>();
            _layout = new ScatterPlotLayout();
            _scatterPlot = new ScatterPlot(_layout, new Rect(), _plots);
            
            _mockFilterRepository = new Mock<IFilterRepository>();
            _mockFilterRepository.Setup(p => p.GetAll()).Returns(_filters);

            _mockDataRepository = new Mock<IRowRepository>();
            _mockDataRepository.Setup(p => p.GetAll()).Returns(_rows);

            _mockViewRepository = new Mock<IViewRepository>();
            _mockViewRepository.Setup(p => p.Get<ScatterPlot>()).Returns(_scatterPlot);

            _mockRenderer = new Mock<IScatterPlotRenderer>();
            _mockRenderer.Setup(p => p.RenderPlots(new List<Row>(), _layout)).Returns(new List<Plot>());
            
            _handler = new UpdatePlotsCommandHandler(
                _mockFilterRepository.Object,
                _mockDataRepository.Object,
                _mockViewRepository.Object,
                _mockRenderer.Object);
        }

        [Test]
        public void TestUpdatePlotsShouldUpdatePlots()
        {
            _handler.Execute(new UpdatePlotsCommand());
            Assert.That(_scatterPlot.GetPlots(), Is.EqualTo(_plots));
        }

        [Test]
        public void TestUpdatePlotsShouldIncludeRowsInsideTheFilter()
        {
            var filter = new BooleanFilter(_column, true, false, false);
            _filters.Add(filter);
            var row = new Row(0, new List<object>() { true });
            _rows.Add(row);
            var plot = new Plot();
            _plots.Add(plot);
            _mockRenderer.Setup(p => p.RenderPlots(_rows, _layout)).Returns(_plots);
            _handler.Execute(new UpdatePlotsCommand());
            Assert.That(_scatterPlot.GetPlots().Count, Is.EqualTo(1));
        }

        [Test]
        public void TestUpdatePlotsShouldExcludeRowsOutsideTheFilter()
        {
            var row = new Row(0, new List<object>() { false });
            _rows.Add(row);
            var filter = new BooleanFilter(_column, true, false, false);
            _filters.Add(filter);
            _handler.Execute(new UpdatePlotsCommand());
            Assert.That(_scatterPlot.GetPlots().Count, Is.EqualTo(0));
        }
    }
}

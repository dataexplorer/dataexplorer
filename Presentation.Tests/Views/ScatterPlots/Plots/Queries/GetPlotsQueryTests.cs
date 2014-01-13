using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Application.Views.ScatterPlots.Queries;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Plots.Renderers;
using Moq;
using NUnit.Framework;
using GetPlotsQuery = DataExplorer.Presentation.Views.ScatterPlots.Plots.Queries.GetPlotsQuery;

namespace DataExplorer.Presentation.Tests.Views.ScatterPlots.Plots.Queries
{
    [TestFixture]
    public class GetPlotsQueryTests
    {
        private GetPlotsQuery _query;
        private Mock<IQueryBus> _mockService;
        private Mock<IPlotRenderer> _mockRenderer;
        private Size _controlSize;
        private Rect _viewExtent;
        private List<PlotDto> _plotDtos;
        private PlotDto _plotDto;
        private List<CanvasItem> _items;
        private CanvasItem _item;

        [SetUp]
        public void SetUp()
        {
            _controlSize = new Size();
            _viewExtent = new Rect();
            _plotDtos = new List<PlotDto> { _plotDto };
            _plotDto = new PlotDto();
            _item = new CanvasCircle();
            _items = new List<CanvasItem> { _item };

            _mockService = new Mock<IQueryBus>();
            _mockService.Setup(p => p.Execute(It.IsAny<GetViewExtentQuery>())).Returns(_viewExtent);
            _mockService.Setup(p => p.Execute(It.IsAny<Application.Views.ScatterPlots.Queries.GetPlotsQuery>()))
                .Returns(_plotDtos);

            _mockRenderer = new Mock<IPlotRenderer>();
            _mockRenderer.Setup(p => p.RenderPlots(_controlSize, _viewExtent, _plotDtos)).Returns(_items);

            _query = new GetPlotsQuery(
                _mockService.Object,
                _mockRenderer.Object);
        }

        [Test]
        public void TestExecuteShouldReturnPlots()
        {
            var results = _query.Execute(_controlSize);
            Assert.That(results.Single(), Is.EqualTo(_item));
        }
    }
}

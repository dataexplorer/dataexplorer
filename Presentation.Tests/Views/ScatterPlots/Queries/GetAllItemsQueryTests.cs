using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Layouts.Location.Queries;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Application.Views.ScatterPlots.Axes.Queries;
using DataExplorer.Application.Views.ScatterPlots.Queries;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.Renderers.Grid;
using DataExplorer.Presentation.Views.ScatterPlots.Renderers.Plots;
using DataExplorer.Presentation.Views.ScatterPlots.Renderers.Titles;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Views.ScatterPlots.Queries
{
    [TestFixture]
    public class GetAllItemsQueryTests
    {
        private GetAllItemsQuery _query;
        private Mock<IQueryBus> _mockQueryBus;
        private Mock<IAxisGridRenderer> _mockGridRenderer;
        private Mock<IPlotRenderer> _mockPlotRenderer;
        private Mock<IAxisTitleRenderer> _mockTitleRenderer;
        private Size _controlSize;
        private Rect _viewExtent;
        private AxisGridLine _axisGridLine;
        private List<AxisGridLine> _axisGridLines; 
        private PlotDto _plotDto;
        private List<PlotDto> _plotDtos; 
        private ColumnDto _columnDto;
        private CanvasLine _xGridLine;
        private CanvasLine _yGridLine;
        private CanvasItem _plotItem;
        private CanvasLabel _xGridLabel;
        private CanvasLabel _yGridLabel;
        private CanvasLabel _xTitleLabel;
        private CanvasLabel _yTitleLabel;

        [SetUp]
        public void SetUp()
        {
            _controlSize = new Size();
            _viewExtent = new Rect();
            _axisGridLine = new AxisGridLine();
            _axisGridLines = new List<AxisGridLine> { _axisGridLine };
            _plotDto = new PlotDto();
            _plotDtos = new List<PlotDto> { _plotDto };
            _columnDto = new ColumnDto() { Name = "test" };
            _xGridLine = new CanvasLine();
            _yGridLine = new CanvasLine();
            _plotItem = new CanvasCircle();
            _xGridLabel = new CanvasLabel();
            _yGridLabel = new CanvasLabel();
            _xTitleLabel = new CanvasLabel();
            _yTitleLabel = new CanvasLabel();
            
            _mockQueryBus = new Mock<IQueryBus>();
            _mockQueryBus.Setup(p => p.Execute(It.IsAny<GetViewExtentQuery>()))
                .Returns(_viewExtent);
            _mockQueryBus.Setup(p => p.Execute(It.IsAny<GetXAxisGridLinesQuery>()))
                .Returns(_axisGridLines);
            _mockQueryBus.Setup(p => p.Execute(It.IsAny<GetYAxisGridLinesQuery>()))
                .Returns(_axisGridLines);
            _mockQueryBus.Setup(p => p.Execute(It.IsAny<GetPlotsQuery>()))
                .Returns(_plotDtos);
            _mockQueryBus.Setup(p => p.Execute(It.IsAny<GetXColumnQuery>()))
                .Returns(_columnDto);
            _mockQueryBus.Setup(p => p.Execute(It.IsAny<GetYColumnQuery>()))
                .Returns(_columnDto);
            
            _mockGridRenderer = new Mock<IAxisGridRenderer>();
            _mockGridRenderer.Setup(p => p.RenderXAxisGridLines(_axisGridLines, _viewExtent, _controlSize))
                .Returns(new List<CanvasLine> { _xGridLine });
            _mockGridRenderer.Setup(p => p.RenderYAxisGridLines(_axisGridLines, _viewExtent, _controlSize))
                .Returns(new List<CanvasLine> { _yGridLine });
            _mockGridRenderer.Setup(p => p.RenderXAxisGridLabels(_axisGridLines, _viewExtent, _controlSize))
                .Returns(new List<CanvasLabel> {_xGridLabel});
            _mockGridRenderer.Setup(p => p.RenderYAxisGridLabels(_axisGridLines, _viewExtent, _controlSize))
                .Returns(new List<CanvasLabel> { _yGridLabel });

            _mockPlotRenderer = new Mock<IPlotRenderer>();
            _mockPlotRenderer.Setup(p => p.RenderPlots(_controlSize, _viewExtent, _plotDtos))
                .Returns(new List<CanvasItem> { _plotItem });
            
            _mockTitleRenderer = new Mock<IAxisTitleRenderer>();
            _mockTitleRenderer.Setup(p => p.RenderXAxisTitle(_controlSize, _columnDto.Name))
                .Returns(_xTitleLabel);
            _mockTitleRenderer.Setup(p => p.RenderYAxisTitle(_controlSize, _columnDto.Name))
                .Returns(_yTitleLabel);

            _query = new GetAllItemsQuery(
                _mockQueryBus.Object,
                _mockGridRenderer.Object,
                _mockPlotRenderer.Object,
                _mockTitleRenderer.Object);
        }

        [Test]
        public void TestExecuteShouldReturnXAxisGridLines()
        {
            var results = _query.Execute(_controlSize);
            Assert.That(results, Has.Member(_xGridLine));
        }

        [Test]
        public void TestExecuteShouldReturnYAxisGridLines()
        {
            var results = _query.Execute(_controlSize);
            Assert.That(results, Has.Member(_yGridLine));
        }

        [Test]
        public void TestExecuteShouldReturnPlotItems()
        {
            var results = _query.Execute(_controlSize);
            Assert.That(results, Has.Member(_plotItem));
        }

        [Test]
        public void TestExecuteShouldReturnXAxisGridLabels()
        {
            var results = _query.Execute(_controlSize);
            Assert.That(results, Has.Member(_xGridLabel));
        }

        [Test]
        public void TestExecuteShouldReturnYAxisGridLabels()
        {
            var results = _query.Execute(_controlSize);
            Assert.That(results, Has.Member(_yGridLabel));
        }

        [Test]
        public void TestExecuteShouldXAxisTitleItem()
        {
            var results = _query.Execute(_controlSize);
            Assert.That(results, Has.Member(_xTitleLabel));
        }

        [Test]
        public void TestExecuteShouldYAxisTitleItem()
        {
            var results = _query.Execute(_controlSize);
            Assert.That(results, Has.Member(_yTitleLabel));
        }
    }
}

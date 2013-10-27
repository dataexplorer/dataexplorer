using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Maps;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Factories;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Renderers;
using DataExplorer.Tests.Application.Maps;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots.AxisGridLines.Queries
{
    [TestFixture]
    public class GetScatterPlotXAxisGridLinesQueryTests
    {
        private GetScatterPlotXAxisGridLinesQuery _query;
        private Mock<IScatterPlotService> _mockScatterPlotService;
        private Mock<IScatterPlotLayoutService> _mockLayoutService;
        private Mock<IMapService> _mockMapService;
        private Mock<IScatterPlotAxisGridLineFactory> _mockFactory;
        private Mock<IXAxisGridLineRenderer> _mockRenderer;
        private Size _controlSize;
        private Rect _viewExtent;
        private ColumnDto _columnDto;
        private IAxisMap _axisMap;
        private List<AxisLine> _axisLines;
        private AxisLine _axisLine;
        private List<CanvasLine> _canvasLines;
        private CanvasLine _canvasLine;

        [SetUp]
        public void SetUp()
        {
            _controlSize = new Size();
            _viewExtent = new Rect();
            _columnDto = new ColumnDto() { Type = typeof(object) };
            _axisMap = new FakeAxisMap();
            _axisLine = new AxisLine();
            _axisLines = new List<AxisLine> { _axisLine };
            _canvasLine = new CanvasLine();
            _canvasLines = new List<CanvasLine> { _canvasLine };

            _mockScatterPlotService = new Mock<IScatterPlotService>();
            _mockScatterPlotService.Setup(p => p.GetViewExtent()).Returns(_viewExtent);

            _mockLayoutService = new Mock<IScatterPlotLayoutService>();
            _mockLayoutService.Setup(p => p.GetXColumn()).Returns(_columnDto);

            _mockMapService = new Mock<IMapService>();
            _mockMapService.Setup(p => p.GetAxisMap(_columnDto, 0d, 1d)).Returns(_axisMap);

            _mockFactory = new Mock<IScatterPlotAxisGridLineFactory>();
            _mockFactory.Setup(p => p.Create(typeof(object), _axisMap, _viewExtent.Left, _viewExtent.Right)).Returns(_axisLines);

            _mockRenderer = new Mock<IXAxisGridLineRenderer>();
            _mockRenderer.Setup(p => p.Render(_axisLines, _viewExtent, _controlSize)).Returns(_canvasLines);

            _query = new GetScatterPlotXAxisGridLinesQuery(
                _mockScatterPlotService.Object,
                _mockLayoutService.Object,
                _mockMapService.Object,
                _mockFactory.Object,
                _mockRenderer.Object);
        }

        [Test]
        public void TestExecuteShouldReturnEmptyListIfColumnDtoIsNull()
        {
            _mockLayoutService.Setup(p => p.GetXColumn()).Returns((ColumnDto) null);
            var results = _query.Execute(_controlSize);
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void TestExecuteShouldReturnGridLines()
        {
            var results = _query.Execute(_controlSize);
            Assert.That(results.Single(), Is.EqualTo(_canvasLine));
        }
    }
}

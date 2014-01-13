using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Columns.Queries;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Maps;
using DataExplorer.Application.Maps.Queries;
using DataExplorer.Application.Tests.Maps;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Queries;
using DataExplorer.Application.Views.ScatterPlots.Queries;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Grid.Factories;
using DataExplorer.Presentation.Views.ScatterPlots.Grid.Labels.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.Grid.Labels.Renderers;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Views.ScatterPlots.Grid.Labels.Queries
{
    [TestFixture]
    public class GetYAxisGridLineLabelsQueryTests
    {
        private GetYAxisGridLabelsQuery _query;
        private Mock<IQueryBus> _mockScatterPlotService;
        private Mock<IQueryBus> _mockQueryBus;
        private Mock<IGridLineFactory> _mockFactory;
        private Mock<IYAxisGridLabelRenderer> _mockRenderer;
        private Size _controlSize;
        private Rect _viewExtent;
        private ColumnDto _columnDto;
        private List<object> _values;
        private IAxisMap _axisMap;
        private List<AxisGridLine> _axisLines;
        private AxisGridLine _axisGridLine;
        private List<CanvasLabel> _canvasLabels;
        private CanvasLabel _canvasLabel;

        [SetUp]
        public void SetUp()
        {
            _controlSize = new Size();
            _viewExtent = new Rect();
            _columnDto = new ColumnDto() { Type = typeof(object) };
            _values = new List<object>();
            _axisMap = new FakeAxisMap();
            _axisGridLine = new AxisGridLine();
            _axisLines = new List<AxisGridLine> { _axisGridLine };
            _canvasLabel = new CanvasLabel();
            _canvasLabels = new List<CanvasLabel> { _canvasLabel };

            _mockQueryBus = new Mock<IQueryBus>();
            _mockQueryBus.Setup(p => p.Execute(
                It.Is<GetDistinctColumnValuesQuery>(q => q.Id == _columnDto.Id)))
                .Returns(_values);
            _mockQueryBus.Setup(p => p.Execute(
                It.Is<GetAxisMapQuery>(q => q.ColumnId == _columnDto.Id 
                    && q.TargetMin == 0d 
                    && q.TargetMax == 1d)))
                .Returns(_axisMap);

            _mockScatterPlotService = new Mock<IQueryBus>();
            _mockScatterPlotService.Setup(p => p.Execute(It.IsAny<GetViewExtentQuery>()))
                .Returns(_viewExtent);
            _mockQueryBus.Setup(p => p.Execute(It.IsAny<GetYColumnQuery>()))
                .Returns(_columnDto);

            _mockFactory = new Mock<IGridLineFactory>();
            _mockFactory.Setup(p => p.Create(typeof(object), _axisMap, _values, _viewExtent.Left, _viewExtent.Right)).Returns(_axisLines);

            _mockRenderer = new Mock<IYAxisGridLabelRenderer>();
            _mockRenderer.Setup(p => p.Render(_axisLines, _viewExtent, _controlSize)).Returns(_canvasLabels);

            _query = new GetYAxisGridLabelsQuery(
                _mockQueryBus.Object,
                _mockFactory.Object,
                _mockRenderer.Object);
        }

        [Test]
        public void TestExecuteShouldReturnEmptyListIfColumnDtoIsNull()
        {
            _mockQueryBus.Setup(p => p.Execute(It.IsAny<GetYColumnQuery>()))
                .Returns((ColumnDto)null);
            var results = _query.Execute(_controlSize);
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void TestExecuteShouldReturnGridLineLabels()
        {
            var results = _query.Execute(_controlSize);
            Assert.That(results.Single(), Is.EqualTo(_canvasLabel));
        }
    }
}

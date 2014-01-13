using System.Collections.Generic;
using System.Windows;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Columns.Queries;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Maps;
using DataExplorer.Application.Maps.Queries;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Application.Views.ScatterPlots.Queries;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Grid.Factories;
using DataExplorer.Presentation.Views.ScatterPlots.Grid.Labels.Renderers;

namespace DataExplorer.Presentation.Views.ScatterPlots.Grid.Labels.Queries
{
    public class GetYAxisGridLabelsQuery : IGetYAxisGridLabelsQuery
    {
        private readonly IQueryBus _queryBus;
        private readonly IScatterPlotLayoutService _layoutService;
        private readonly IGridLineFactory _factory;
        private readonly IYAxisGridLabelRenderer _renderer;

        public GetYAxisGridLabelsQuery(
            IQueryBus queryBus,
            IScatterPlotLayoutService layoutService, 
            IGridLineFactory factory, 
            IYAxisGridLabelRenderer renderer)
        {
            _queryBus = queryBus;
            _layoutService = layoutService;
            _factory = factory;
            _renderer = renderer;
        }

        public IEnumerable<CanvasLabel> Execute(Size controlSize)
        {
            var viewExtent = _queryBus.Execute(new GetViewExtentQuery());

            var columnDto = _layoutService.GetYColumn();

            if (columnDto == null)
                return new List<CanvasLabel>();

            var map = _queryBus.Execute(new GetAxisMapQuery(columnDto.Id, 0d, 1d));

            var values = _queryBus.Execute(new GetDistinctColumnValuesQuery(columnDto.Id));

            var axisLines = _factory.Create(columnDto.Type, map, values, viewExtent.Top, viewExtent.Bottom);

            var canvasLabels = _renderer.Render(axisLines, viewExtent, controlSize);

            return canvasLabels;
        }
    }
}

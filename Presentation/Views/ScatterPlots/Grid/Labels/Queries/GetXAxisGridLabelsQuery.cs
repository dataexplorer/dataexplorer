using System.Collections.Generic;
using System.Windows;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Columns.Queries;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Maps;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Grid.Factories;
using DataExplorer.Presentation.Views.ScatterPlots.Grid.Labels.Renderers;

namespace DataExplorer.Presentation.Views.ScatterPlots.Grid.Labels.Queries
{
    public class GetXAxisGridLabelsQuery : IGetXAxisGridLabelsQuery
    {
        private readonly IQueryBus _queryBus;
        private readonly IScatterPlotService _scatterPlotService;
        private readonly IScatterPlotLayoutService _layoutService;
        private readonly IMapService _mapService;
        private readonly IGridLineFactory _factory;
        private readonly IXAxisGridLabelRenderer _renderer;

        public GetXAxisGridLabelsQuery(
            IQueryBus queryBus, 
            IScatterPlotService scatterPlotService, 
            IScatterPlotLayoutService layoutService, 
            IMapService mapService,
            IGridLineFactory factory, 
            IXAxisGridLabelRenderer renderer)
        {
            _queryBus = queryBus;
            _layoutService = layoutService;
            _mapService = mapService;
            _factory = factory;
            _renderer = renderer;
            _scatterPlotService = scatterPlotService;
        }

        public IEnumerable<CanvasLabel> Execute(Size controlSize)
        {
            var viewExtent = _scatterPlotService.GetViewExtent();

            var columnDto = _layoutService.GetXColumn();

            if (columnDto == null)
                return new List<CanvasLabel>();

            var map = _mapService.GetAxisMap(columnDto, 0d, 1d);

            var values = _queryBus.Execute(new GetDistinctColumnValuesQuery(columnDto.Id));

            var axisLines = _factory.Create(columnDto.Type, map, values, viewExtent.Left, viewExtent.Right);

            var canvasLabels = _renderer.Render(axisLines, viewExtent, controlSize);

            return canvasLabels;
        }
    }
}

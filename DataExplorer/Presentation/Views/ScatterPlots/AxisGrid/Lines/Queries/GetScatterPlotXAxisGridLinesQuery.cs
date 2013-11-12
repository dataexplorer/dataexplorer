using System.Collections.Generic;
using System.Windows;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Maps;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGrid.Factories;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGrid.Lines.Renderers;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisGrid.Lines.Queries
{
    public class GetScatterPlotXAxisGridLinesQuery : IGetScatterPlotXAxisGridLinesQuery
    {
        private readonly IScatterPlotService _scatterPlotService;
        private readonly IScatterPlotLayoutService _layoutService;
        private readonly IMapService _mapService;
        private readonly IColumnService _columnService;
        private readonly IScatterPlotAxisGridLineFactory _factory;
        private readonly IXAxisGridLineRenderer _renderer;

        public GetScatterPlotXAxisGridLinesQuery(
            IScatterPlotService scatterPlotService, 
            IScatterPlotLayoutService layoutService, 
            IMapService mapService, 
            IColumnService columnService,
            IScatterPlotAxisGridLineFactory factory, 
            IXAxisGridLineRenderer renderer)
        {
            _layoutService = layoutService;
            _mapService = mapService;
            _columnService = columnService;
            _factory = factory;
            _renderer = renderer;
            _scatterPlotService = scatterPlotService;
        }

        public IEnumerable<CanvasLine> Execute(Size controlSize)
        {
            var viewExtent = _scatterPlotService.GetViewExtent();

            var columnDto = _layoutService.GetXColumn();

            if (columnDto == null)
                return new List<CanvasLine>();

            var map = _mapService.GetAxisMap(columnDto, 0d, 1d);

            var values = _columnService.GetDistinctColumnValues(columnDto.Id);

            var axisLines = _factory.Create(columnDto.Type, map, values, viewExtent.Left, viewExtent.Right);

            var canvasLines = _renderer.Render(axisLines, viewExtent, controlSize);

            return canvasLines;
        }
    }
}

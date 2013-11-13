using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Maps;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGrid.Factories;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGrid.Labels.Renderers;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisGrid.Labels.Queries
{
    public class GetScatterPlotYAxisGridLabelsQuery : IGetScatterPlotYAxisGridLabelsQuery
    {
        private readonly IScatterPlotService _scatterPlotService;
        private readonly IScatterPlotLayoutService _layoutService;
        private readonly IMapService _mapService;
        private readonly IColumnService _columnService;
        private readonly IScatterPlotAxisGridLineFactory _factory;
        private readonly IYAxisGridLabelRenderer _renderer;

        public GetScatterPlotYAxisGridLabelsQuery(
            IScatterPlotService scatterPlotService, 
            IScatterPlotLayoutService layoutService, 
            IMapService mapService, 
            IColumnService columnService,
            IScatterPlotAxisGridLineFactory factory, 
            IYAxisGridLabelRenderer renderer)
        {
            _layoutService = layoutService;
            _mapService = mapService;
            _columnService = columnService;
            _factory = factory;
            _renderer = renderer;
            _scatterPlotService = scatterPlotService;
        }

        public IEnumerable<CanvasLabel> Execute(Size controlSize)
        {
            var viewExtent = _scatterPlotService.GetViewExtent();

            var columnDto = _layoutService.GetYColumn();

            if (columnDto == null)
                return new List<CanvasLabel>();

            var map = _mapService.GetAxisMap(columnDto, 0d, 1d);

            var values = _columnService.GetDistinctColumnValues(columnDto.Id);

            var axisLines = _factory.Create(columnDto.Type, map, values, viewExtent.Top, viewExtent.Bottom);

            var canvasLabels = _renderer.Render(axisLines, viewExtent, controlSize);

            return canvasLabels;
        }
    }
}

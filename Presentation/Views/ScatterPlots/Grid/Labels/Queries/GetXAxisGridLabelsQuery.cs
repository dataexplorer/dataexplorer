using System.Collections.Generic;
using System.Windows;
using DataExplorer.Application.Columns.Queries;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Maps.Queries;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Queries;
using DataExplorer.Application.Views.ScatterPlots.Queries;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Grid.Factories;
using DataExplorer.Presentation.Views.ScatterPlots.Grid.Labels.Renderers;

namespace DataExplorer.Presentation.Views.ScatterPlots.Grid.Labels.Queries
{
    public class GetXAxisGridLabelsQuery : IGetXAxisGridLabelsQuery
    {
        private readonly IQueryBus _queryBus;
        private readonly IGridLineFactory _factory;
        private readonly IXAxisGridLabelRenderer _renderer;

        public GetXAxisGridLabelsQuery(
            IQueryBus queryBus, 
            IGridLineFactory factory, 
            IXAxisGridLabelRenderer renderer)
        {
            _queryBus = queryBus;
            _factory = factory;
            _renderer = renderer;
        }

        public IEnumerable<CanvasLabel> Execute(Size controlSize)
        {
            var viewExtent = _queryBus.Execute(new GetViewExtentQuery());

            var columnDto = _queryBus.Execute(new GetXColumnQuery());

            if (columnDto == null)
                return new List<CanvasLabel>();

            var map = _queryBus.Execute(new GetAxisMapQuery(columnDto.Id, 0d, 1d));

            var values = _queryBus.Execute(new GetDistinctColumnValuesQuery(columnDto.Id));

            var axisLines = _factory.Create(columnDto.Type, map, values, viewExtent.Left, viewExtent.Right);

            var canvasLabels = _renderer.Render(axisLines, viewExtent, controlSize);

            return canvasLabels;
        }
    }
}

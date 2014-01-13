using System.Collections.Generic;
using System.Windows;
using DataExplorer.Application.Columns.Queries;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Maps.Queries;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Queries;
using DataExplorer.Application.Views.ScatterPlots.Queries;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Grid.Factories;
using DataExplorer.Presentation.Views.ScatterPlots.Grid.Lines.Renderers;

namespace DataExplorer.Presentation.Views.ScatterPlots.Grid.Lines.Queries
{
    public class GetXAxisGridLinesQuery : IGetXAxisGridLinesQuery
    {
        private readonly IQueryBus _queryBus;
        private readonly IGridLineFactory _factory;
        private readonly IXAxisGridLineRenderer _renderer;

        public GetXAxisGridLinesQuery(
            IQueryBus queryBus,
            IGridLineFactory factory, 
            IXAxisGridLineRenderer renderer)
        {
            _queryBus = queryBus;
            _factory = factory;
            _renderer = renderer;
        }

        public IEnumerable<CanvasLine> Execute(Size controlSize)
        {
            var viewExtent = _queryBus.Execute(new GetViewExtentQuery());

            var columnDto = _queryBus.Execute(new GetXColumnQuery());

            if (columnDto == null)
                return new List<CanvasLine>();

            var map = _queryBus.Execute(new GetAxisMapQuery(columnDto.Id, 0d, 1d));

            var values = _queryBus.Execute(new GetDistinctColumnValuesQuery(columnDto.Id));

            var axisLines = _factory.Create(columnDto.Type, map, values, viewExtent.Left, viewExtent.Right);

            var canvasLines = _renderer.Render(axisLines, viewExtent, controlSize);

            return canvasLines;
        }
    }
}

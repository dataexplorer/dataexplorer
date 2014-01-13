using System.Collections.Generic;
using System.Windows;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Views.ScatterPlots.Queries;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Plots.Renderers;

namespace DataExplorer.Presentation.Views.ScatterPlots.Plots.Queries
{
    public class GetPlotsQuery : IGetPlotsQuery
    {
        private readonly IQueryBus _queryBus;
        private readonly IPlotRenderer _renderer;

        public GetPlotsQuery(
            IQueryBus queryBus, 
            IPlotRenderer renderer)
        {
            _queryBus = queryBus;
            _renderer = renderer;
        }

        public IEnumerable<CanvasItem> Execute(Size controlSize)
        {
            var viewExtent = _queryBus.Execute(new GetViewExtentQuery());

            var plots = _queryBus.Execute(new Application.Views.ScatterPlots.Queries.GetPlotsQuery());

            var canvasPlots = _renderer.RenderPlots(controlSize, viewExtent, plots);

            foreach (var canvasPlot in canvasPlots)
                yield return canvasPlot;
        }
    }
}

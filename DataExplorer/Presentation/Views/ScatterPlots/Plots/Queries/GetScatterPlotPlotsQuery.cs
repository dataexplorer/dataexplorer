using System.Collections.Generic;
using System.Windows;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Plots.Renderers;

namespace DataExplorer.Presentation.Views.ScatterPlots.Plots.Queries
{
    public class GetScatterPlotPlotsQuery : IGetScatterPlotPlotsQuery
    {
        private readonly IScatterPlotService _service;
        private readonly IScatterPlotPlotRenderer _renderer;

        public GetScatterPlotPlotsQuery(
            IScatterPlotService service, 
            IScatterPlotPlotRenderer renderer)
        {
            _service = service;
            _renderer = renderer;
        }

        public IEnumerable<ICanvasItem> Execute(Size controlSize)
        {
            var viewExtent = _service.GetViewExtent();

            var plots = _service.GetPlots();

            var canvasPlots = _renderer.RenderPlots(controlSize, viewExtent, plots);

            foreach (var canvasPlot in canvasPlots)
                yield return canvasPlot;
        }
    }
}

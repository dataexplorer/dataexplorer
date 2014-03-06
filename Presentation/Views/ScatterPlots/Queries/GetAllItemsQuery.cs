using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Layouts.Location.Queries;
using DataExplorer.Application.Views.ScatterPlots.Axes.Queries;
using DataExplorer.Application.Views.ScatterPlots.Queries;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Renderers.Grid;
using DataExplorer.Presentation.Views.ScatterPlots.Renderers.Plots;
using DataExplorer.Presentation.Views.ScatterPlots.Renderers.Titles;

namespace DataExplorer.Presentation.Views.ScatterPlots.Queries
{
    public class GetAllItemsQuery : IGetAllItemsQuery
    {
        private readonly IQueryBus _queryBus;
        private readonly IAxisGridRenderer _gridRenderer;
        private readonly IPlotRenderer _plotRenderer;
        private readonly IAxisTitleRenderer _titleRenderer;

        public GetAllItemsQuery(
            IQueryBus queryBus,
            IAxisGridRenderer gridRenderer,
            IPlotRenderer plotRenderer,
            IAxisTitleRenderer titleRenderer)
        {
            _queryBus = queryBus;
            _gridRenderer = gridRenderer;
            _plotRenderer = plotRenderer;
            _titleRenderer = titleRenderer;
        }

        // TODO: Is there any possible way to refactor this to make it more readable?
        public IEnumerable<CanvasItem> Execute(Size controlSize)
        {
            var viewExtent = _queryBus.Execute(new GetViewExtentQuery());

            var xGridLines = _queryBus.Execute(new GetXAxisGridLinesQuery());

            var yGridLines = _queryBus.Execute(new GetYAxisGridLinesQuery());

            var xAxisGridLines = _gridRenderer.RenderXAxisGridLines(xGridLines, viewExtent, controlSize);

            foreach (var xGridLine in xAxisGridLines)
                yield return xGridLine;

            var yAxisGridLines = _gridRenderer.RenderYAxisGridLines(yGridLines, viewExtent, controlSize);

            foreach (var yGridLine in yAxisGridLines)
                yield return yGridLine;

            var plots = _queryBus.Execute(new GetPlotsQuery());

            var canvasPlots = _plotRenderer.RenderPlots(controlSize, viewExtent, plots);

            foreach (var canvasPlot in canvasPlots)
                yield return canvasPlot;

            var xAxisGridLabels = _gridRenderer.RenderXAxisGridLabels(xGridLines, viewExtent, controlSize);

            foreach (var xAxisGridLabel in xAxisGridLabels)
                yield return xAxisGridLabel;

            var yAxisGridLabels = _gridRenderer.RenderYAxisGridLabels(yGridLines, viewExtent, controlSize);

            foreach (var yAxisGridLabel in yAxisGridLabels)
                yield return yAxisGridLabel;

            var xColumn = _queryBus.Execute(new GetXAxisColumnQuery());

            var xTitle = xColumn != null
                ? xColumn.Name
                : string.Empty;

            yield return _titleRenderer.RenderXAxisTitle(controlSize, xTitle);

            var yColumn = _queryBus.Execute(new GetYAxisColumnQuery());

            var yTitle = yColumn != null
                ? yColumn.Name
                : string.Empty;

            yield return _titleRenderer.RenderYAxisTitle(controlSize, yTitle);
        }
    }
}

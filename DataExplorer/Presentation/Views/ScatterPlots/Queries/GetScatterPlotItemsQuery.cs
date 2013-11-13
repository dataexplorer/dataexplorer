using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGrid.Labels.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGrid.Lines.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.AxisTitles.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.Plots;
using DataExplorer.Presentation.Views.ScatterPlots.Plots.Queries;

namespace DataExplorer.Presentation.Views.ScatterPlots.Queries
{
    public class GetScatterPlotItemsQuery : IGetScatterPlotItemsQuery
    {
        private readonly IGetScatterPlotXAxisGridLinesQuery _getXAxisGridLinesQuery;
        private readonly IGetScatterPlotYAxisGridLinesQuery _getYAxisGridLinesQuery;
        private readonly IGetScatterPlotPlotsQuery _getPlotsQuery;
        private readonly IGetScatterPlotXAxisGridLabelsQuery _getXAxisGridLabelsQuery;
        private readonly IGetScatterPlotYAxisGridLabelsQuery _getYAxisGridLabelsQuery;
        private readonly IGetScatterPlotXAxisTitleQuery _getXAxisTitleQuery;
        private readonly IGetScatterPlotYAxisTitleQuery _getYAxisTitleQuery;

        public GetScatterPlotItemsQuery(
            IGetScatterPlotXAxisGridLinesQuery getXAxisGridLinesQuery,
            IGetScatterPlotYAxisGridLinesQuery getYAxisGridLinesQuery,
            IGetScatterPlotPlotsQuery getPlotsQuery,
            IGetScatterPlotXAxisGridLabelsQuery getXAxisGridLabelsQuery,
            IGetScatterPlotYAxisGridLabelsQuery getYAxisGridLabelsQuery,
            IGetScatterPlotXAxisTitleQuery getXAxisTitleQuery,
            IGetScatterPlotYAxisTitleQuery getYAxisTitleQuery)
        {
            _getPlotsQuery = getPlotsQuery;
            _getXAxisGridLabelsQuery = getXAxisGridLabelsQuery;
            _getYAxisGridLabelsQuery = getYAxisGridLabelsQuery;
            _getXAxisTitleQuery = getXAxisTitleQuery;
            _getYAxisTitleQuery = getYAxisTitleQuery;
            _getXAxisGridLinesQuery = getXAxisGridLinesQuery;
            _getYAxisGridLinesQuery = getYAxisGridLinesQuery;
        }

        public IEnumerable<ICanvasItem> Execute(Size controlSize)
        {
            var xGridLines = _getXAxisGridLinesQuery.Execute(controlSize);

            foreach (var xGridLine in xGridLines)
                yield return xGridLine;

            var yGridLines = _getYAxisGridLinesQuery.Execute(controlSize);

            foreach (var yGridLine in yGridLines)
                yield return yGridLine;

            var plotItems = _getPlotsQuery.Execute(controlSize);

            foreach (var canvasItem in plotItems)
                yield return canvasItem;

            var xAxisGridLabels = _getXAxisGridLabelsQuery.Execute(controlSize);

            foreach (var xAxisGridLabel in xAxisGridLabels)
                yield return xAxisGridLabel;

            var yAxisGridLabels = _getYAxisGridLabelsQuery.Execute(controlSize);

            foreach (var yAxisGridLabel in yAxisGridLabels)
                yield return yAxisGridLabel;

            var xAxisTitleItem = _getXAxisTitleQuery.Execute(controlSize);

            if (xAxisTitleItem != null)
                yield return xAxisTitleItem;

            var yAxisTitleItem = _getYAxisTitleQuery.Execute(controlSize);
            
            if (yAxisTitleItem != null)
                yield return yAxisTitleItem;
        }
    }
}

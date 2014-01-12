using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Grid;
using DataExplorer.Presentation.Views.ScatterPlots.Plots.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.Titles;

namespace DataExplorer.Presentation.Views.ScatterPlots.Queries
{
    public class GetAllItemsQuery : IGetAllItemsQuery
    {
        private readonly IGridQueries _gridQueries;
        private readonly IGetPlotsQuery _getPlotsQuery;
        private readonly ITitleQueries _titleQueries;

        public GetAllItemsQuery(
            IGridQueries gridQueries,
            IGetPlotsQuery getPlotsQuery,
            ITitleQueries titleQueries)
        {
            _gridQueries = gridQueries;
            _getPlotsQuery = getPlotsQuery;
            _titleQueries = titleQueries;
        }

        public IEnumerable<CanvasItem> Execute(Size controlSize)
        {
            var xGridLines = _gridQueries.GetXAxisGridLines(controlSize);

            foreach (var xGridLine in xGridLines)
                yield return xGridLine;

            var yGridLines = _gridQueries.GetYAxisGridLines(controlSize);

            foreach (var yGridLine in yGridLines)
                yield return yGridLine;

            var plotItems = _getPlotsQuery.Execute(controlSize);

            foreach (var canvasItem in plotItems)
                yield return canvasItem;

            var xAxisGridLabels = _gridQueries.GetXAxisGridLabels(controlSize);

            foreach (var xAxisGridLabel in xAxisGridLabels)
                yield return xAxisGridLabel;

            var yAxisGridLabels = _gridQueries.GetYAxisGridLabels(controlSize);

            foreach (var yAxisGridLabel in yAxisGridLabels)
                yield return yAxisGridLabel;

            var xAxisTitleItem = _titleQueries.GetXAxisTitle(controlSize);

            if (xAxisTitleItem != null)
                yield return xAxisTitleItem;

            var yAxisTitleItem = _titleQueries.GetYAxisTitle(controlSize);
            
            if (yAxisTitleItem != null)
                yield return yAxisTitleItem;
        }
    }
}

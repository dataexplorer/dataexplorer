using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Queries
{
    public class GetScatterPlotItemsQuery : IGetScatterPlotItemsQuery
    {
        private readonly IGetScatterPlotPlotsQuery _getPlotsQuery;
        private readonly IGetScatterPlotXAxisTitleQuery _getXAxisTitleQuery;
        private readonly IGetScatterPlotYAxisTitleQuery _getYAxisTitleQuery;

        public GetScatterPlotItemsQuery(
            IGetScatterPlotPlotsQuery getPlotsQuery, 
            IGetScatterPlotXAxisTitleQuery getXAxisTitleQuery, 
            IGetScatterPlotYAxisTitleQuery getYAxisTitleQuery)
        {
            _getPlotsQuery = getPlotsQuery;
            _getXAxisTitleQuery = getXAxisTitleQuery;
            _getYAxisTitleQuery = getYAxisTitleQuery;
        }

        public IEnumerable<ICanvasItem> Execute(Size controlSize)
        {
            var plotItems = _getPlotsQuery.Execute(controlSize);

            foreach (var canvasItem in plotItems)
                yield return canvasItem;

            var xAxisTitleItem = _getXAxisTitleQuery.Execute(controlSize);

            if (xAxisTitleItem != null)
                yield return xAxisTitleItem;

            var yAxisTitleItem = _getYAxisTitleQuery.Execute(controlSize);
            
            if (yAxisTitleItem != null)
                yield return yAxisTitleItem;
        }
    }
}

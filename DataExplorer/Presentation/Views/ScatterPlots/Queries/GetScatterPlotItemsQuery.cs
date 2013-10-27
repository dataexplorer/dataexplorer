﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.AxisTitles.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.Plots;
using DataExplorer.Presentation.Views.ScatterPlots.Plots.Queries;

namespace DataExplorer.Presentation.Views.ScatterPlots.Queries
{
    public class GetScatterPlotItemsQuery : IGetScatterPlotItemsQuery
    {
        private readonly IGetScatterPlotXAxisGridLinesQuery _getXAxisGridLinesQuery;
        private readonly IGetScatterPlotPlotsQuery _getPlotsQuery;
        private readonly IGetScatterPlotXAxisTitleQuery _getXAxisTitleQuery;
        private readonly IGetScatterPlotYAxisTitleQuery _getYAxisTitleQuery;

        public GetScatterPlotItemsQuery(
            IGetScatterPlotXAxisGridLinesQuery getXAxisGridLinesQuery, 
            IGetScatterPlotPlotsQuery getPlotsQuery, 
            IGetScatterPlotXAxisTitleQuery getXAxisTitleQuery, 
            IGetScatterPlotYAxisTitleQuery getYAxisTitleQuery)
        {
            _getPlotsQuery = getPlotsQuery;
            _getXAxisTitleQuery = getXAxisTitleQuery;
            _getYAxisTitleQuery = getYAxisTitleQuery;
            _getXAxisGridLinesQuery = getXAxisGridLinesQuery;
        }

        public IEnumerable<ICanvasItem> Execute(Size controlSize)
        {
            var xGridLines = _getXAxisGridLinesQuery.Execute(controlSize);

            foreach (var xGridLine in xGridLines)
                yield return xGridLine;

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
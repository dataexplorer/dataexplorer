using System.Collections.Generic;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Grid.Labels.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.Grid.Lines.Queries;

namespace DataExplorer.Presentation.Views.ScatterPlots.Grid
{
    public class GridQueries : IGridQueries
    {
        private readonly IGetXAxisGridLabelsQuery _getXLabelsQuery;
        private readonly IGetYAxisGridLabelsQuery _getYLabelsQuery;
        private readonly IGetXAxisGridLinesQuery _getXLinesQuery;
        private readonly IGetYAxisGridLinesQuery _getYLinesQuery;

        public GridQueries(
            IGetXAxisGridLabelsQuery getXLabelsQuery, 
            IGetYAxisGridLabelsQuery getYLabelsQuery, 
            IGetXAxisGridLinesQuery getXLinesQuery, 
            IGetYAxisGridLinesQuery getYLinesQuery)
        {
            _getXLabelsQuery = getXLabelsQuery;
            _getYLabelsQuery = getYLabelsQuery;
            _getXLinesQuery = getXLinesQuery;
            _getYLinesQuery = getYLinesQuery;
        }

        public IEnumerable<CanvasLabel> GetXAxisGridLabels(Size controlSize)
        {
            return _getXLabelsQuery.Execute(controlSize);
        }

        public IEnumerable<CanvasLabel> GetYAxisGridLabels(Size controlSize)
        {
            return _getYLabelsQuery.Execute(controlSize);
        }

        public IEnumerable<CanvasLine> GetXAxisGridLines(Size controlSize)
        {
            return _getXLinesQuery.Execute(controlSize);
        }

        public IEnumerable<CanvasLine> GetYAxisGridLines(Size controlSize)
        {
            return _getYLinesQuery.Execute(controlSize);
        }
    }
}

using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Titles.Queries;

namespace DataExplorer.Presentation.Views.ScatterPlots.Titles
{
    public class TitleQueries : ITitleQueries
    {
        private readonly IGetXAxisTitleQuery _getXAxisTitleQuery;
        private readonly IGetYAxisTitleQuery _getYAxisTitleQuery;

        public TitleQueries(
            IGetXAxisTitleQuery getXAxisTitleQuery, 
            IGetYAxisTitleQuery getYAxisTitleQuery)
        {
            _getXAxisTitleQuery = getXAxisTitleQuery;
            _getYAxisTitleQuery = getYAxisTitleQuery;
        }

        public CanvasLabel GetXAxisTitle(Size controlSize)
        {
            return _getXAxisTitleQuery.Execute(controlSize);
        }

        public CanvasLabel GetYAxisTitle(Size controlSize)
        {
            return _getYAxisTitleQuery.Execute(controlSize);
        }
    }
}

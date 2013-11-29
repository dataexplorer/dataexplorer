using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Queries;

namespace DataExplorer.Presentation.Views.ScatterPlots
{
    public class ScatterPlotViewModelQueries : IScatterPlotViewModelQueries
    {
        private readonly IGetAllItemsQuery _getItemsQuery;
        private readonly IGetSelectedItemsQuery _getSelectedItemsQuery;

        public ScatterPlotViewModelQueries(
            IGetAllItemsQuery getItemsQuery, 
            IGetSelectedItemsQuery getSelectedItemsQuery)
        {
            _getItemsQuery = getItemsQuery;
            _getSelectedItemsQuery = getSelectedItemsQuery;
        }

        public IEnumerable<CanvasItem> GetItems(Size controlSize)
        {
            return _getItemsQuery.Execute(controlSize);
        }

        public IEnumerable<CanvasItem> GetSelectedItems(IEnumerable<CanvasItem> items)
        {
            return _getSelectedItemsQuery.Execute(items);
        }
    }
}

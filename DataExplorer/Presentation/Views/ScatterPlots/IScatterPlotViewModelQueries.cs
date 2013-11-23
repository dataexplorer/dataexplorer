using System.Collections.Generic;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots
{
    public interface IScatterPlotViewModelQueries
    {
        IEnumerable<CanvasItem> GetItems(Size controlSize);
        IEnumerable<CanvasItem> GetSelectedItems(IEnumerable<CanvasItem> items);
    }
}
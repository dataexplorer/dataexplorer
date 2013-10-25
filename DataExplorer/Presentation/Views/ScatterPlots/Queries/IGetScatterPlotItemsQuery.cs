using System.Collections.Generic;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Queries
{
    public interface IGetScatterPlotItemsQuery
    {
        IEnumerable<ICanvasItem> Execute(Size controlSize);
    }
}
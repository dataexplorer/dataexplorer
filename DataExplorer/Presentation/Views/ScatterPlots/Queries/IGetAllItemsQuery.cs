using System.Collections.Generic;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Queries
{
    public interface IGetAllItemsQuery
    {
        IEnumerable<CanvasItem> Execute(Size controlSize);
    }
}
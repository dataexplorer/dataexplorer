using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots
{
    public interface IScatterPlotViewModel
    {
        List<CanvasItem> Items { get; }

        ICollection<CanvasItem> SelectedItems { get; } 
    }
}
using System.Collections.Generic;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots
{
    public interface IScatterPlotViewModel
    {
        List<CanvasItem> Items { get; }
    }
}
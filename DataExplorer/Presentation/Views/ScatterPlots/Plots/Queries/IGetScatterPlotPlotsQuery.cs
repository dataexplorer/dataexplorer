using System.Collections.Generic;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Plots.Queries
{
    public interface IGetScatterPlotPlotsQuery
    {
        IEnumerable<ICanvasItem> Execute(Size controlSize);
    }
}

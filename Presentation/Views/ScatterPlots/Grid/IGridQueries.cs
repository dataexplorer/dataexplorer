using System.Collections.Generic;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Grid
{
    public interface IGridQueries
    {
        IEnumerable<CanvasLabel> GetXAxisGridLabels(Size controlSize);
        IEnumerable<CanvasLabel> GetYAxisGridLabels(Size controlSize);
        IEnumerable<CanvasLine> GetXAxisGridLines(Size controlSize);
        IEnumerable<CanvasLine> GetYAxisGridLines(Size controlSize);
    }
}
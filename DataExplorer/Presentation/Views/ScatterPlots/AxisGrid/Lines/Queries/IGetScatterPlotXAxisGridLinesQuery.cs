using System.Collections.Generic;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisGrid.Lines.Queries
{
    public interface IGetScatterPlotXAxisGridLinesQuery
    {
        IEnumerable<CanvasLine> Execute(Size controlSize);
    }
}
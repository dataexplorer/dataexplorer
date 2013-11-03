using System.Collections.Generic;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisGrid.Labels.Queries
{
    public interface IGetScatterPlotXAxisGridLabelsQuery
    {
        IEnumerable<CanvasLabel> Execute(Size controlSize);
    }
}

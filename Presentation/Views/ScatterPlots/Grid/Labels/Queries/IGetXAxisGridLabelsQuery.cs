using System.Collections.Generic;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Grid.Labels.Queries
{
    public interface IGetXAxisGridLabelsQuery
    {
        IEnumerable<CanvasLabel> Execute(Size controlSize);
    }
}

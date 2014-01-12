using System.Collections.Generic;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Grid.Lines.Queries
{
    public interface IGetXAxisGridLinesQuery
    {
        IEnumerable<CanvasLine> Execute(Size controlSize);
    }
}
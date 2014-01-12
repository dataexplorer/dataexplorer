using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots
{
    public interface IScatterPlotViewModelCommands
    {
        void Resize(Size controlSize);

        void ZoomIn(Point center, Size size);

        void ZoomOut(Point center, Size size);

        void Pan(Vector vector, Size size);
        
        void Select(List<CanvasItem> item);
    }
}

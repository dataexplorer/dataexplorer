using System.Collections.Generic;
using System.Windows;

namespace DataExplorer.Domain.Views.ScatterPlots
{
    public interface IScatterPlot
    {
        Rect GetViewExtent();

        void SetViewExtent(Rect viewExtent);
        
        void SetPlots(List<Plot> plots);
        
        List<Plot> GetPlots();
        
        ScatterPlotLayout GetLayout();
    }
}

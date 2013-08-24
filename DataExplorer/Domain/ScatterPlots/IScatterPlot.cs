using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Domain.Views;

namespace DataExplorer.Domain.ScatterPlots
{
    public interface IScatterPlot : IView
    {
        Rect GetViewExtent();
        void SetViewExtent(Rect viewExtent);
        void SetPlots(List<Plot> plots);
        List<Plot> GetPlots();
        ScatterPlotLayout GetLayout();
    }
}

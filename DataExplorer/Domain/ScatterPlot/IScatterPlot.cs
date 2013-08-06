using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataExplorer.Domain.ScatterPlot
{
    public interface IScatterPlot
    {
        Rect GetViewExtent();
        void SetViewExtent(Rect viewExtent);
        void SetPlots(List<Plot> plots);
        List<Plot> GetPlots();
    }
}

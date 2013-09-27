using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataExplorer.Application.ScatterPlots.Tasks
{
    public interface IZoomOutTask
    {
        void ZoomOut(Point center);
    }
}

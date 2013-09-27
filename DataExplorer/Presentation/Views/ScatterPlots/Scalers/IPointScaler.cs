using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataExplorer.Presentation.Views.ScatterPlots.Scalers
{
    public interface IPointScaler
    {
        Point ScalePoint(Point center, Size controlSize, Rect viewExtent);
    }
}

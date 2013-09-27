using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataExplorer.Presentation.Views.ScatterPlots.Calculations
{
    public interface IVectorScaler
    {
        Vector ScaleVector(Vector vector, Size controlSize, Rect viewExtent);
    }
}

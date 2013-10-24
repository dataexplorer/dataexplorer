using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataExplorer.Presentation.Views.ScatterPlots.Scalers
{
    public class ScaleComputer : IScaleComputer
    {
        public double ComputeScale(Size controlSize, Rect viewExtent)
        {
            return (controlSize.Width > controlSize.Height)
                ? controlSize.Width / viewExtent.Width
                : controlSize.Height / viewExtent.Height;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Views.ScatterPlots.Scalers;

namespace DataExplorer.Presentation.Views.ScatterPlots
{
    public class ScatterPlotViewScaler : IScatterPlotViewScaler
    {
        private readonly IPointScaler _pointScaler;
        private readonly IVectorScaler _vectorScaler;

        public ScatterPlotViewScaler(
            IPointScaler pointScaler,
            IVectorScaler vectorScaler)
        {
            _pointScaler = pointScaler;
            _vectorScaler = vectorScaler;
        }

        public Point ScalePoint(Point center, Size controlSize, Rect viewExtent)
        {
            return _pointScaler.ScalePoint(center, controlSize, viewExtent);
        }

        public Vector ScaleVector(Vector vector, Size controlSize, Rect viewExtent)
        {
            return _vectorScaler.ScaleVector(vector, controlSize, viewExtent);
        }
    }
}

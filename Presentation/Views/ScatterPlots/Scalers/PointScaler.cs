using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataExplorer.Presentation.Views.ScatterPlots.Scalers
{
    public class PointScaler : IPointScaler
    {
        public Point ScalePoint(Point center, Size controlSize, Rect viewExtent)
        {
            var scaledX = (center.X / controlSize.Width * viewExtent.Width) - (viewExtent.Width / 2);

            var scaledY = (-1) * ((center.Y / controlSize.Height * viewExtent.Height) - (viewExtent.Height / 2));

            return new Point(scaledX, scaledY);
        }
    }
}

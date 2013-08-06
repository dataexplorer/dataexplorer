using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Core.Geometry;

namespace DataExplorer.Presentation.Views.ScatterPlot
{
    public class GeometryCalculator : IGeometryCalculator
    {
        public Rect CalculateExtent(Size controlSize, Rect viewExtent, double scale, Point plotCenter)
        {
            var x = CalculateX(plotCenter.X, viewExtent.X, scale);
            var y = CalculateY(plotCenter.Y, viewExtent.Y, scale, controlSize.Height);
            var width = 16;
            var height = 16;
            return new Rect(x, y, width, height);
        }

        private double CalculateX(double itemX, double viewX, double scale)
        {
            return (itemX - viewX) * scale;
        }

        private double CalculateY(double itemY, double viewY, double scale, double actualHeight)
        {
            return actualHeight - (itemY - viewY) * scale; ;
        }
    }
}

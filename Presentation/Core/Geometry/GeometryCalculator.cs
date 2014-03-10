using System.Windows;

namespace DataExplorer.Presentation.Core.Geometry
{
    public class GeometryCalculator : IGeometryCalculator
    {
        private const int MaxSize = 128;
        private const int LabelHeight = 10;
        private const int LabelMargin = 5;

        // TODO: Should I refector the last three parameters to a single PlotDto?
        public Rect CalculatePlotExtent(Size controlSize, Rect viewExtent, double scale, Point plotCenter, double plotSize)
        {
            var x = CalculateX(plotCenter.X, viewExtent.X, scale, plotSize);
            
            var y = CalculateY(plotCenter.Y, viewExtent.Y, scale, plotSize, controlSize.Height);
            
            var width = CalculateSize(plotSize);
            
            var height = CalculateSize(plotSize);

            return new Rect(x, y, width, height);
        }

        public Point CalcluateLabelOrigin(Rect plotExtent)
        {
            var x = plotExtent.X;

            var y = plotExtent.Y + (plotExtent.Height / 2) + LabelHeight + LabelMargin;

            return new Point(x, y);
        }
        
        private double CalculateX(double itemX, double viewX, double scale, double plotSize)
        {
            return ((itemX - viewX) * scale); // - (0.5d * MaxSize * plotSize);
        }

        private double CalculateY(double itemY, double viewY, double scale, double plotSize, double actualHeight)
        {
            return actualHeight - ((itemY - viewY) * scale); // + (0.5d * MaxSize * plotSize);
        }

        private double CalculateSize(double plotSize)
        {
            return MaxSize * plotSize;
        }    
    }
}

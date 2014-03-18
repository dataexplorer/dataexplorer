using System.Windows.Media.Imaging;
using DataExplorer.Domain.Colors;

namespace DataExplorer.Application.Views.ScatterPlots
{
    public class PlotDto
    {
        public int Id;

        public double X;
        
        public double Y;

        public Color Color;

        public double Size;

        public BitmapImage Image;

        public string Label;
    }
}

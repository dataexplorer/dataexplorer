using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Core.Canvas.Factories
{
    public interface IGeometryFactory
    {
        CanvasCircle CreateCircle(int id, Rect shapeExtent, Color color);

        CanvasImage CreateImage(int id, Rect extent, BitmapImage image);

        CanvasLabel CreateLabel(int id, Point origin, string text);
    }
}

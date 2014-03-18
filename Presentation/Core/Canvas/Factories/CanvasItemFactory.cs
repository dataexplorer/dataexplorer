using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Core.Canvas.Factories
{
    public class CanvasItemFactory : IGeometryFactory
    {
        public CanvasCircle CreateCircle(int id, Rect shapeExtent, Color color)
        {
            var circle = new CanvasCircle
            {
                Id = id,
                X = shapeExtent.X,
                Y = shapeExtent.Y,
                Radius = shapeExtent.Width / 2,
                Color = color
            };
            return circle;
        }

        public CanvasImage CreateImage(int id, Rect extent, BitmapImage image)
        {
            var canvasImage = new CanvasImage()
            {
                Id = id,
                X = extent.X,
                Y = extent.Y,
                Width = extent.Width,
                Height = extent.Height,
                Image = image
            };

            return canvasImage;
        }

        public CanvasLabel CreateLabel(int id, Point origin, string text)
        {
            var label = new CanvasLabel
            {
                Id = id,
                X = origin.X,
                Y = origin.Y,
                IsRotated = false,
                IsSelected = false,
                Text = text
            };

            return label;
        }
    }
}

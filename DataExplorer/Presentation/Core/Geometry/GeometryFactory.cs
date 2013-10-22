using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Core.Geometry
{
    public class GeometryFactory : IGeometryFactory
    {
        public CanvasCircle CreateCircle(Rect shapeExtent)
        {
            var circle = new CanvasCircle();
            circle.X = shapeExtent.X;
            circle.Y = shapeExtent.Y;
            circle.Radius = shapeExtent.Width / 2;
            return circle;
        }
    }
}

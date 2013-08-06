using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataExplorer.Presentation.Core.Geometry
{
    public class GeometryFactory : IGeometryFactory
    {
        public Circle CreateCircle(Rect shapeExtent)
        {
            var circle = new Circle();
            circle.X = shapeExtent.X;
            circle.Y = shapeExtent.Y;
            circle.Radius = shapeExtent.Width / 2;
            return circle;
        }
    }
}

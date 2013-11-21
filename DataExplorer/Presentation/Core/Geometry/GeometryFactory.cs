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
        public CanvasCircle CreateCircle(int id, Rect shapeExtent)
        {
            var circle = new CanvasCircle
            {
                Id = id,
                X = shapeExtent.X,
                Y = shapeExtent.Y,
                Radius = shapeExtent.Width / 2
            };
            return circle;
        }
    }
}

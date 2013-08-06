using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataExplorer.Presentation.Core.Geometry
{
    public interface IGeometryFactory
    {
        Circle CreateCircle(Rect shapeExtent);
    }
}

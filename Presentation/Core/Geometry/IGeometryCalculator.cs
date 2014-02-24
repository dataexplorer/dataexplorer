using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataExplorer.Presentation.Core.Geometry
{
    public interface IGeometryCalculator
    {
        Rect CalculateExtent(Size controlSize, Rect viewExtent, double scale, Point plotCenter, double plotSize);
    }
}

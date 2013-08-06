using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using DataExplorer.Presentation.Core.Geometry;

namespace DataExplorer.Presentation.Core.Canvas
{
    public interface ICanvasRenderer
    {
        List<Visual> DrawVisuals(List<Circle> plots);
        Visual DrawCircle(Circle circle);
    }
}

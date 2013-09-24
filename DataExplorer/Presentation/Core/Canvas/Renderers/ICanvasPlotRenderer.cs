using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using DataExplorer.Presentation.Core.Geometry;

namespace DataExplorer.Presentation.Core.Canvas.Renderers
{
    public interface ICanvasPlotRenderer
    {
        IEnumerable<Visual> DrawPlots(List<Circle> plots);
    }
}

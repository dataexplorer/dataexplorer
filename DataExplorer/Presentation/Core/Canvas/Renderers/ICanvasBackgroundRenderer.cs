using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DataExplorer.Presentation.Core.Canvas.Renderers
{
    public interface ICanvasBackgroundRenderer
    {
        Visual DrawBackground(double width, double height);
    }
}

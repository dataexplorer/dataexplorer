using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DataExplorer.Presentation.Panes.Legend.Colors
{
    public interface IColorLegendItem
    {
        Color Color { get; }

        string Label { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Panes.Legend.Colors;

namespace DataExplorer.Presentation.Panes.Legend
{
    public interface ILegendPaneViewModel
    {
        IColorLegendViewModel ColorLegendViewModel { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Presentation.Panes.Legend.Colors
{
    public interface IColorLegendViewModel
    {
        string Title { get; }
       
        List<ColorLegendItemViewModel> Items { get; }
    }
}

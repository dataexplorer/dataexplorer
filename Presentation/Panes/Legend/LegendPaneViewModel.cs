using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Panes.Legend.Colors;

namespace DataExplorer.Presentation.Panes.Legend
{
    public class LegendPaneViewModel 
        : BaseViewModel,
        ILegendPaneViewModel
    {
        private readonly IColorLegendViewModel _colorLegendViewModel;

        public LegendPaneViewModel(IColorLegendViewModel colorLegendViewModel)
        {
            _colorLegendViewModel = colorLegendViewModel;
        }

        public IColorLegendViewModel ColorLegendViewModel
        {
            get { return _colorLegendViewModel; }
        }
    }
}

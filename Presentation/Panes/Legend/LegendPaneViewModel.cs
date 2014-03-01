using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Panes.Legend.Colors;
using DataExplorer.Presentation.Panes.Legend.Sizes;

namespace DataExplorer.Presentation.Panes.Legend
{
    public class LegendPaneViewModel 
        : BaseViewModel,
        ILegendPaneViewModel
    {
        private readonly IColorLegendViewModel _colorLegendViewModel;
        private readonly ISizeLegendViewModel _sizeLegendViewModel;

        public LegendPaneViewModel(
            IColorLegendViewModel colorLegendViewModel,
            ISizeLegendViewModel sizeLegendViewModel)
        {
            _colorLegendViewModel = colorLegendViewModel;
            _sizeLegendViewModel = sizeLegendViewModel;
        }

        public IColorLegendViewModel ColorLegendViewModel
        {
            get { return _colorLegendViewModel; }
        }

        public ISizeLegendViewModel SizeLegendViewModel
        {
            get { return _sizeLegendViewModel; }
        }
    }
}

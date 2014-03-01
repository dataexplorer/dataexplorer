using System;
using System.Collections.Generic;

namespace DataExplorer.Presentation.Panes.Legend.Sizes
{
    public interface ISizeLegendViewModel
    {
        string Title { get; }

        List<SizeLegendItemViewModel> Items { get; }
    }
}

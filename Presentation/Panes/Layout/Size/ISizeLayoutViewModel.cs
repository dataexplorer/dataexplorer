using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Core.Layout;

namespace DataExplorer.Presentation.Panes.Layout.Size
{
    public interface ISizeLayoutViewModel
    {
        string Label { get; }

        List<LayoutItemViewModel> Columns { get; }

        LayoutItemViewModel SelectedColumn { get; }

        bool IsLowerSizeSliderVisible { get; }

        double MinSizeSliderValue { get; }

        double MaxSizeSliderValue { get; }

        double LowerSizeSliderValue { get; }

        double UpperSizeSliderValue { get; }
    }
}

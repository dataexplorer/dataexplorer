using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Core.Layout;

namespace DataExplorer.Presentation.Panes.Layout.Link
{
    public interface ILinkLayoutViewModel
    {
        string Label { get; }

        List<LayoutItemViewModel> Columns { get; }

        LayoutItemViewModel SelectedColumn { get; }
    }
}

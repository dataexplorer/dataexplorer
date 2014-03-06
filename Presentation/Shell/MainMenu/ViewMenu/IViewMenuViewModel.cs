using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataExplorer.Presentation.Shell.MainMenu.ViewMenu
{
    public interface IViewMenuViewModel
    {
        ICommand ShowNavigationPaneCommand { get; }

        ICommand ShowFilterPaneCommand { get; }

        ICommand ShowLayoutPaneCommand { get; }

        ICommand ShowLegendPaneCommand { get; }

        ICommand ShowPropertyPaneCommand { get; }

        ICommand ZoomToFullExtentCommand { get; }

        ICommand ClearLayoutCommand { get; }
    }
}

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
        ICommand ZoomToFullExtentCommand { get; }
    }
}

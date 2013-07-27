using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Shell.MainMenu.FileMenu;

namespace DataExplorer.Presentation.Shell.MainMenu
{
    public interface IMainMenuViewModel
    {
        IFileMenuViewModel FileMenuViewModel { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataExplorer.Presentation.Shell.MainMenu.HelpMenu
{
    public interface IHelpMenuViewModel
    {
        ICommand ViewHelpCommand { get; }

        ICommand ViewAboutCommand { get; }
    }
}

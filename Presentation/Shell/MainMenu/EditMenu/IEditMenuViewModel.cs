using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataExplorer.Presentation.Shell.MainMenu.EditMenu
{
    public interface IEditMenuViewModel
    {
        ICommand CopyCommand { get; }

        

    }
}

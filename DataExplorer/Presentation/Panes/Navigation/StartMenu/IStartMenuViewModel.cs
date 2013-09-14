using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataExplorer.Presentation.Panes.Navigation.StartMenu
{
    public interface IStartMenuViewModel
    {
        ICommand OpenCommand { get; }
        
        ICommand ImportCommand  { get; }

        ICommand DownloadDataCommand { get; }
        
    }
}

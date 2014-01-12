using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataExplorer.Presentation.Views.ScatterPlots
{
    public interface IScatterPlotContextMenuViewModel
    {
        ICommand CopyCommand { get; }

        ICommand ZoomToFullExtentCommand { get; }
        
        ICommand ClearLayoutCommand { get; }
    }
}

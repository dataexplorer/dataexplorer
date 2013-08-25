using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataExplorer.Presentation.Core.Events;

namespace DataExplorer.Presentation.Importers.CsvFile
{
    public interface ICsvFileImportViewModel
    {
        event DialogClosedEvent DialogClosed;

        string FilePath { get; set; }
        
        ICommand BrowseCommand { get; }
        
        ICommand ImportCommand { get; }
        
        ICommand CancelCommand { get; }
    }
}

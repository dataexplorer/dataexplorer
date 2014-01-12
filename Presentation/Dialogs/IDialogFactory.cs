using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Dialogs.Open;
using DataExplorer.Presentation.Dialogs.Save;
using DataExplorer.Presentation.Importers.CsvFile;

namespace DataExplorer.Presentation.Dialogs
{
    public interface IDialogFactory
    {
        IDialog CreateImportCsvFileDialog();

        IOpenFileDialog CreateOpenFileDialog();
        
        ISaveFileDialog CreateSaveFileDialog();
    }
}

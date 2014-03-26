using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Dialogs.Exceptions;
using DataExplorer.Presentation.Dialogs.Open;
using DataExplorer.Presentation.Dialogs.Save;
using DataExplorer.Presentation.Importers.CsvFile;

namespace DataExplorer.Presentation.Dialogs
{
    public class DialogFactory : IDialogFactory
    {
        public IDialog CreateImportCsvFileDialog()
        {
            return new ImportCsvFileDialog();
        }

        public IOpenFileDialog CreateOpenFileDialog()
        {
            return new OpenFileDialogWrapper();
        }

        public ISaveFileDialog CreateSaveFileDialog()
        {
            return new SaveFileDialogWrapper();
        }

        public IExceptionDialog CreateExceptionDialog()
        {
            return new ExceptionDialog();
        }
    }
}

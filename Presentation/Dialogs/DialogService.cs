using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using DataExplorer.Application;
using DataExplorer.Presentation.Dialogs.Import;
using DataExplorer.Presentation.Dialogs.Open;
using DataExplorer.Presentation.Dialogs.Save;

namespace DataExplorer.Presentation.Dialogs
{
    public class DialogService : IDialogService
    {
        private readonly IImportDialogService _importService;
        private readonly IOpenDialogService _openService;
        private readonly ISaveDialogService _saveService;
        private readonly IExceptionDialogService _exceptionService;

        public DialogService(
            IImportDialogService importService,
            IOpenDialogService openService,
            ISaveDialogService saveService,
            IExceptionDialogService exceptionService)
        {
            _importService = importService;
            _openService = openService;
            _saveService = saveService;
            _exceptionService = exceptionService;
        }

        public void ShowImportDialog()
        {
            _importService.Show();
        }

        public string ShowOpenDialog()
        {
            return _openService.Show();
        }

        public string ShowSaveDialog()
        {
            return _saveService.Show();
        }

        public void ShowExceptionDialog(Exception ex)
        {
           _exceptionService.Show(ex);
        }
    }
}

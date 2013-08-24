using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Application;
using DataExplorer.Presentation.Importers.CsvFile;

namespace DataExplorer.Presentation.Dialogs
{
    public class DialogService : IDialogService
    {
        private readonly IDialogFactory _factory;
        private readonly IApplication _application;
        private readonly ICsvFileImportViewModel _csvFileImportViewModel;

        public DialogService(
            IDialogFactory factory, 
            IApplication application,
            ICsvFileImportViewModel csvFileImportViewModel)
        {
            _factory = factory;
            _application = application;
            _csvFileImportViewModel = csvFileImportViewModel;
        }

        public void ShowImportDialog()
        {
            var dialog = _factory.CreateImportCsvFileDialog();
            dialog.DataContext = _csvFileImportViewModel;
            dialog.Owner = _application.GetMainWindow();
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dialog.ShowDialog();
        }
    }
}

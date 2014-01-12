using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using DataExplorer.Application;
using DataExplorer.Application.Application;
using DataExplorer.Presentation.Importers.CsvFile;

namespace DataExplorer.Presentation.Dialogs
{
    public class DialogService : IDialogService
    {
        private const string SaveDialogTitle = "Save";
        private const string OpenDialogTitle = "Open";
        private const string DefaultFileExtension = ".xml";
        private const string FileFilter = "Data Explorer Projects|*.xml";

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
            if (Dispatcher.CurrentDispatcher.Thread.IsBackground)
            {
                Dispatcher.CurrentDispatcher.Invoke(ShowImportDialog);
                return;
            }

            var dialog = _factory.CreateImportCsvFileDialog();
            dialog.DataContext = _csvFileImportViewModel;
            dialog.Owner = _application.GetMainWindow();
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dialog.ShowDialog();
        }

        public string ShowOpenDialog()
        {
            if (Dispatcher.CurrentDispatcher.Thread.IsBackground)
                return Dispatcher.CurrentDispatcher.Invoke((Func<string>) ShowOpenDialog);

            var dialog = _factory.CreateOpenFileDialog();
            dialog.SetTitle(OpenDialogTitle);
            dialog.SetDefaultExtension(DefaultFileExtension);
            dialog.SetFilter(FileFilter);
            
            var result = dialog.ShowDialog();

            if (!result.HasValue || !result.Value)
                return null;

            var filePath = dialog.GetFilePath();

            return filePath;
        }

        public string ShowSaveDialog()
        {
            if (Dispatcher.CurrentDispatcher.Thread.IsBackground)
                return Dispatcher.CurrentDispatcher.Invoke((Func<string>) ShowSaveDialog);

            var dialog = _factory.CreateSaveFileDialog();
            dialog.SetTitle(SaveDialogTitle);
            dialog.SetDefaultExtension(DefaultFileExtension);
            dialog.SetFilter(FileFilter);

            var result = dialog.ShowDialog();

            if (!result.HasValue || !result.Value)
                return null;

            var filePath = dialog.GetFilePath();

            return filePath;
        }
    }
}

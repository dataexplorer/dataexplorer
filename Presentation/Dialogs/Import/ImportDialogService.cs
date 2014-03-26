using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using DataExplorer.Application.Application;
using DataExplorer.Presentation.Importers.CsvFile;

namespace DataExplorer.Presentation.Dialogs.Import
{
    public class ImportDialogService : IImportDialogService
    {
        private readonly IDialogFactory _factory;
        private readonly IApplication _application;
        private readonly ICsvFileImportViewModel _viewModel;

        public ImportDialogService(
            IDialogFactory factory, 
            IApplication application, 
            ICsvFileImportViewModel viewModel)
        {
            _factory = factory;
            _application = application;
            _viewModel = viewModel;
        }

        public void Show()
        {
            if (Dispatcher.CurrentDispatcher.Thread.IsBackground)
            {
                Dispatcher.CurrentDispatcher.Invoke(Show);
                return;
            }

            var dialog = _factory.CreateImportCsvFileDialog();
            dialog.DataContext = _viewModel;
            dialog.Owner = _application.GetMainWindow();
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            dialog.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataExplorer.Application.Importers.CsvFile;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Dialogs;

namespace DataExplorer.Presentation.Importers.CsvFile
{
    public class CsvFileImportViewModel : BaseViewModel, ICsvFileImportViewModel
    {
        private const string FileFilter = "CSV documents|*.csv";
        private const string DefaultFileExtension = ".csv";

        private readonly ICsvFileImportService _service;
        private readonly IDialogFactory _dialogService;
        private readonly DelegateCommand _browseCommand;

        public string FilePath
        {
            get { return _service.GetFilePath(); }
            set { _service.SetFilePath(value);}
        }

        public CsvFileImportViewModel(
            ICsvFileImportService service,
            IDialogFactory dialogService)
        {
            _service = service;
            _dialogService = dialogService;
            _browseCommand = new DelegateCommand(Browse);

            _service.FilePathChanged += HandleFilePathChanged;
        }

        public ICommand BrowseCommand
        {
            get { return _browseCommand; }
        }

        private void Browse(object parameter)
        {
            var dialog = _dialogService.CreateOpenFileDialog();
            dialog.SetDefaultExtension(DefaultFileExtension);
            dialog.SetFilter(FileFilter);
            var result = dialog.ShowDialog();

            if (result == true)
                _service.SetFilePath(dialog.GetFilePath());
        }

        private void HandleFilePathChanged(object sender, EventArgs e)
        {
            OnPropertyChanged(() => FilePath);
        }
    }
}

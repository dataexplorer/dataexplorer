using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataExplorer.Application.Importers.CsvFile;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Core.Commands;
using DataExplorer.Presentation.Core.Events;
using DataExplorer.Presentation.Dialogs;

namespace DataExplorer.Presentation.Importers.CsvFile
{
    public class CsvFileImportViewModel : BaseViewModel, ICsvFileImportViewModel
    {
        private const string FileFilter = "CSV documents|*.csv";
        private const string DefaultFileExtension = ".csv";

        private readonly ICsvFileImportService _service;
        private readonly IDialogFactory _dialogFactory;
        private readonly DelegateCommand _browseCommand;
        private readonly AsyncDelegateCommand _importCommand;
        private readonly DelegateCommand _cancelCommand;

        private bool _isImporting;
        private double _progress;

        public event DialogClosedEvent DialogClosed;

        public string FilePath
        {
            get { return _service.GetFilePath(); }
            set { _service.SetFilePath(value);}
        }

        public CsvFileImportViewModel(
            ICsvFileImportService service,
            IDialogFactory dialogFactory)
        {
            _service = service;
            _dialogFactory = dialogFactory;
            _browseCommand = new DelegateCommand(Browse);
            _importCommand = new AsyncDelegateCommand(Import, CanImport);
            _cancelCommand = new DelegateCommand(Cancel);

            _service.FilePathChanged += HandleFilePathChanged;
            _service.DataImporting += HandleDataImporting;
            _service.DataImported += HandleDataImported;
            _service.DataImportProgressChanged += HandleDataImportProgressChanged;

            _isImporting = false;
            _progress = 0;
        }
        
        public ICommand BrowseCommand
        {
            get { return _browseCommand; }
        }

        public ICommand ImportCommand
        {
            get { return _importCommand; }
        }

        public ICommand CancelCommand
        {
            get { return _cancelCommand; }
        }

        public bool IsProgressBarVisible
        {
            get { return _isImporting; }
        }

        public double Progress
        {
            get { return _progress; }
        }

        private void Browse(object parameter)
        {
            var dialog = _dialogFactory.CreateOpenFileDialog();
            dialog.SetDefaultExtension(DefaultFileExtension);
            dialog.SetFilter(FileFilter);

            var result = dialog.ShowDialog();

            if (result == true)
                _service.SetFilePath(dialog.GetFilePath());
        }

        private bool CanImport(object parameter)
        {
            return _service.CanImport();
        }

        private void Import(object obj)
        {
            _service.Import();
        }

        private void Cancel(object obj)
        {
            if (DialogClosed != null)
                DialogClosed(this, EventArgs.Empty);
        }

        private void HandleFilePathChanged(object sender, EventArgs e)
        {
            OnPropertyChanged(() => FilePath);
            
            _importCommand.RaiseCanExecuteChanged();
        }

        private void HandleDataImporting(object sender, EventArgs e)
        {
            _isImporting = true;

            _progress = 0;

            OnPropertyChanged(() => IsProgressBarVisible);

            OnPropertyChanged(() => Progress);
        }

        private void HandleDataImported(object sender, EventArgs e)
        {
            _isImporting = false;

            _progress = 0;

            OnPropertyChanged(() => IsProgressBarVisible);

            OnPropertyChanged(() => Progress);

            if (DialogClosed != null)
                DialogClosed(this, EventArgs.Empty);
        }

        private void HandleDataImportProgressChanged(object sender, DataImportProgressChangedEventArgs e)
        {
            _progress = e.Progress;

            OnPropertyChanged(() => Progress);
        }
    }
}

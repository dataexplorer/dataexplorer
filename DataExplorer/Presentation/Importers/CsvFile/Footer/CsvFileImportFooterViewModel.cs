using System;
using System.Windows.Input;
using System.Windows.Threading;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Importers.CsvFile;
using DataExplorer.Application.Importers.CsvFile.Events;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Core.Commands;
using DataExplorer.Presentation.Core.Events;

namespace DataExplorer.Presentation.Importers.CsvFile.Footer
{
    public class CsvFileImportFooterViewModel : 
        BaseViewModel,
        ICsvFileImportFooterViewModel,
        IAppHandler<CsvFileSourceChangedEvent>,
        IAppHandler<CsvFileImportingEvent>,
        IAppHandler<CsvFileImportedEvent>,
        IAppHandler<CsvFileImportProgressChangedEvent>
    {
        private readonly ICsvFileImportService _service;
        private readonly AsyncDelegateCommand _importCommand;
        private readonly DelegateCommand _cancelCommand;

        private bool _isImporting;
        private double _progress;

        public event DialogClosedEvent DialogClosed;

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

        public CsvFileImportFooterViewModel(ICsvFileImportService service)
        {
            _service = service;
            _importCommand = new AsyncDelegateCommand(Import, CanImport);
            _cancelCommand = new DelegateCommand(Cancel);

            _isImporting = false;
            _progress = 0;
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

        public void Handle(CsvFileSourceChangedEvent args)
        {
            _importCommand.RaiseCanExecuteChanged();
        }

        public void Handle(CsvFileImportingEvent args)
        {
            _isImporting = true;

            _progress = 0;

            OnPropertyChanged(() => IsProgressBarVisible);

            OnPropertyChanged(() => Progress);
        }

        public void Handle(CsvFileImportedEvent args)
        {
            _isImporting = false;

            _progress = 0;

            OnPropertyChanged(() => IsProgressBarVisible);

            OnPropertyChanged(() => Progress);

            if (DialogClosed != null)
                DialogClosed(this, EventArgs.Empty);
        }

        public void Handle(CsvFileImportProgressChangedEvent args)
        {
            _progress = args.Progress;

            OnPropertyChanged(() => Progress);
        }
    }
}

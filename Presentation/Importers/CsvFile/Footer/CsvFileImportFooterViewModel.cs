using System;
using System.Windows.Input;
using System.Windows.Threading;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Importers.CsvFiles.Commands;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Importers.CsvFiles.Queries;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Core.Commands;
using DataExplorer.Presentation.Core.Events;

namespace DataExplorer.Presentation.Importers.CsvFile.Footer
{
    public class CsvFileImportFooterViewModel : 
        BaseViewModel,
        ICsvFileImportFooterViewModel,
        IEventHandler<CsvFileSourceChangedEvent>,
        IEventHandler<SourceImportingEvent>,
        IEventHandler<SourceImportedEvent>,
        IEventHandler<SourceImportProgressChangedEvent>
    {
        private readonly IMessageBus _messageBus;
        private readonly DelegateCommand _importCommand;
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

        public CsvFileImportFooterViewModel(IMessageBus messageBus)
        {
            _messageBus = messageBus;
            _importCommand = new DelegateCommand(Import, CanImport);
            _cancelCommand = new DelegateCommand(Cancel);

            _isImporting = false;
            _progress = 0;
        }

        private bool CanImport(object parameter)
        {
            return _messageBus.Execute(new CanImportQuery());
        }

        private void Import(object obj)
        {
            _messageBus.Execute(new ImportCsvFileSourceCommand());
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

        public void Handle(SourceImportingEvent args)
        {
            _isImporting = true;

            _progress = 0;

            OnPropertyChanged(() => IsProgressBarVisible);

            OnPropertyChanged(() => Progress);
        }

        public void Handle(SourceImportedEvent args)
        {
            _isImporting = false;

            _progress = 0;

            OnPropertyChanged(() => IsProgressBarVisible);

            OnPropertyChanged(() => Progress);

            if (DialogClosed != null)
                DialogClosed(this, EventArgs.Empty);
        }

        public void Handle(SourceImportProgressChangedEvent args)
        {
            _progress = args.Progress;

            OnPropertyChanged(() => Progress);
        }
    }
}

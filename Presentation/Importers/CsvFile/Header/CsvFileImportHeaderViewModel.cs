using System.ComponentModel;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Importers.CsvFiles;
using DataExplorer.Application.Importers.CsvFiles.Commands;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Importers.CsvFiles.Queries;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Core.Commands;
using DataExplorer.Presentation.Dialogs;
using ICommand = System.Windows.Input.ICommand;

namespace DataExplorer.Presentation.Importers.CsvFile.Header
{
    public class CsvFileImportHeaderViewModel :
        BaseViewModel,
        ICsvFileImportHeaderViewModel,
        IEventHandler<CsvFileSourceChangedEvent>
    {
        private const string FileFilter = "CSV documents|*.csv";
        private const string DefaultFileExtension = ".csv";

        private readonly IMessageBus _messageBus;
        private readonly IDialogFactory _dialogFactory;
        private readonly DelegateCommand _browseCommand;
        
        public string FilePath
        {
            get { return GetFilePath(); }
        }

        public ICommand BrowseCommand
        {
            get { return _browseCommand; }
        }

        public CsvFileImportHeaderViewModel(
            IMessageBus messageBus,
            IDialogFactory dialogFactory)
        {
            _messageBus = messageBus;
            _dialogFactory = dialogFactory;
            _browseCommand = new DelegateCommand(Browse);
        }

        private string GetFilePath()
        {
            var source = _messageBus.Execute(new GetCsvFileSourceQuery());
                
            return source.FilePath;
        }

        private void Browse(object parameter)
        {
            var dialog = _dialogFactory.CreateOpenFileDialog();
            dialog.SetDefaultExtension(DefaultFileExtension);
            dialog.SetFilter(FileFilter);

            var result = dialog.ShowDialog();
            
            if (result == true)
                _messageBus.Execute(new UpdateCsvFileSourceCommand(dialog.GetFilePath()));
        }
        
        public void Handle(CsvFileSourceChangedEvent args)
        {
            OnPropertyChanged(() => FilePath);
        }
    }
}

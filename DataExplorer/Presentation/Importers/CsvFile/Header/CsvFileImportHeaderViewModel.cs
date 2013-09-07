using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataExplorer.Application.Events;
using DataExplorer.Application.Importers.CsvFile;
using DataExplorer.Application.Importers.CsvFile.Events;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Core.Commands;
using DataExplorer.Presentation.Dialogs;

namespace DataExplorer.Presentation.Importers.CsvFile
{
    public class CsvFileImportHeaderViewModel 
        : BaseViewModel,
        ICsvFileImportHeaderViewModel,
        IAppHandler<CsvFilePathChangedAppEvent>
    {
        private const string FileFilter = "CSV documents|*.csv";
        private const string DefaultFileExtension = ".csv";

        private readonly ICsvFileImportService _service;
        private readonly IDialogFactory _dialogFactory;
        private readonly DelegateCommand _browseCommand;

        public string FilePath
        {
            get { return _service.GetFilePath(); }
            set { _service.SetFilePath(value); }
        }

        public ICommand BrowseCommand
        {
            get { return _browseCommand; }
        }

        public CsvFileImportHeaderViewModel(
            ICsvFileImportService service,
            IDialogFactory dialogFactory)
        {
            _service = service;
            _dialogFactory = dialogFactory;
            _browseCommand = new DelegateCommand(Browse);
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
        
        public void Handle(CsvFilePathChangedAppEvent args)
        {
            OnPropertyChanged(() => FilePath);
        }
    }
}

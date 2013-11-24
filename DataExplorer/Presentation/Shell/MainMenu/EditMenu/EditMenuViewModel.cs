using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataExplorer.Application.Clipboard;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Rows;
using DataExplorer.Presentation.Core.Commands;

namespace DataExplorer.Presentation.Shell.MainMenu.EditMenu
{
    public class EditMenuViewModel 
        : IEditMenuViewModel,
        IEventHandler<SelectedRowsChangedEvent>
    {
        private readonly IClipboardService _clipboardService;
        private readonly DelegateCommand _copyCommand;
        
        public EditMenuViewModel(IClipboardService clipboardService)
        {
            _clipboardService = clipboardService;

            _copyCommand = new DelegateCommand(
                p => _clipboardService.Copy(),
                p => _clipboardService.CanCopy());
        }

        public ICommand CopyCommand
        {
            get { return _copyCommand; }
        }
        
        public void Handle(SelectedRowsChangedEvent args)
        {
            _copyCommand.RaiseCanExecuteChanged();
        }
    }
}

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
        private readonly DelegateCommand _copyImageCommand;

        public EditMenuViewModel(IClipboardService clipboardService)
        {
            _clipboardService = clipboardService;

            _copyCommand = new DelegateCommand(
                p => _clipboardService.Copy(),
                p => _clipboardService.CanCopy());

            _copyImageCommand = new DelegateCommand(
                p => _clipboardService.CopyImage());
        }

        public ICommand CopyCommand
        {
            get { return _copyCommand; }
        }

        public ICommand CopyImageCommand
        {
            get { return _copyImageCommand; }
        }

        public void Handle(SelectedRowsChangedEvent args)
        {
            _copyCommand.RaiseCanExecuteChanged();
        }
    }
}

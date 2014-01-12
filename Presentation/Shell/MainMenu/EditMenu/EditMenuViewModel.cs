using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Clipboard;
using DataExplorer.Application.Clipboard.Commands;
using DataExplorer.Application.Clipboard.Queries;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Rows;
using DataExplorer.Presentation.Core.Commands;
using ICommand = System.Windows.Input.ICommand;

namespace DataExplorer.Presentation.Shell.MainMenu.EditMenu
{
    public class EditMenuViewModel 
        : IEditMenuViewModel,
        IEventHandler<SelectedRowsChangedEvent>
    {
        private readonly IMessageBus _messageBus;
        private readonly DelegateCommand _copyCommand;
        private readonly DelegateCommand _copyImageCommand;

        public EditMenuViewModel(IMessageBus messageBus)
        {
            _messageBus = messageBus;

            _copyCommand = new DelegateCommand(
                p => _messageBus.Execute(new CopyDataToClipboardCommand()),
                p => _messageBus.Execute(new CanCopyDataToClipboardQuery()));

            _copyImageCommand = new DelegateCommand(
                p => _messageBus.Execute(new CopyImageToClipboardCommand()));
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

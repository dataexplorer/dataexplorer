using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataExplorer.Application.Clipboard;
using DataExplorer.Application.Clipboard.Commands;
using DataExplorer.Application.Clipboard.Queries;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Rows;
using DataExplorer.Application.Rows.Events;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Application.Views.ScatterPlots.Commands;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Commands;
using DataExplorer.Presentation.Core.Commands;

namespace DataExplorer.Presentation.Views.ScatterPlots
{
    public class ScatterPlotContextMenuViewModel 
        : IScatterPlotContextMenuViewModel,
        IEventHandler<SelectedRowsChangedEvent>
    {
        private readonly IMessageBus _messageBus;
        private readonly DelegateCommand _copyCommand;
        private readonly DelegateCommand _copyImageCommand;
        private readonly DelegateCommand _zoomToFullExtentCommand;
        private readonly DelegateCommand _clearLayoutCommand;

        public ScatterPlotContextMenuViewModel(IMessageBus messageBus)
        {
            _messageBus = messageBus;

            _copyCommand = new DelegateCommand(
                p => _messageBus.Execute(new CopyDataToClipboardCommand()), 
                p => _messageBus.Execute(new CanCopyDataToClipboardQuery()));

            _copyImageCommand = new DelegateCommand(
                p => _messageBus.Execute(new CopyImageToClipboardCommand()));

            _zoomToFullExtentCommand = new DelegateCommand(
                p => _messageBus.Execute(new ZoomToFullExtentCommand()));

            _clearLayoutCommand = new DelegateCommand(
                p => _messageBus.Execute(new ClearLayoutCommand()));
        }

        public ICommand CopyCommand
        {
            get { return _copyCommand; }
        }

        public ICommand CopyImageCommand
        {
            get { return _copyImageCommand; }
        }

        public ICommand ZoomToFullExtentCommand
        {
            get { return _zoomToFullExtentCommand; }
        }

        public ICommand ClearLayoutCommand
        {
            get { return _clearLayoutCommand;}
        }

        public void Handle(SelectedRowsChangedEvent args)
        {
            _copyCommand.RaiseCanExecuteChanged();
        }
    }
}

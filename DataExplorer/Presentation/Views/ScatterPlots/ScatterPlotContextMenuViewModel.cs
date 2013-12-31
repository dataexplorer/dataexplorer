using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataExplorer.Application.Clipboard;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Rows;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Presentation.Core.Commands;

namespace DataExplorer.Presentation.Views.ScatterPlots
{
    public class ScatterPlotContextMenuViewModel 
        : IScatterPlotContextMenuViewModel,
        IEventHandler<SelectedRowsChangedEvent>
    {
        private readonly IClipboardService _clipboardService;
        private readonly IScatterPlotService _scatterplotService;
        private readonly IScatterPlotLayoutService _layoutService;
        private readonly DelegateCommand _copyCommand;
        private readonly DelegateCommand _copyImageCommand;
        private readonly DelegateCommand _zoomToFullExtentCommand;
        private readonly DelegateCommand _clearLayoutCommand;

        public ScatterPlotContextMenuViewModel(
            IClipboardService clipboardService,
            IScatterPlotService scatterplotService,
            IScatterPlotLayoutService layoutService)
        {
            _clipboardService = clipboardService;
            _scatterplotService = scatterplotService;
            _layoutService = layoutService;

            _copyCommand = new DelegateCommand(
                p => _clipboardService.Copy(), 
                p => _clipboardService.CanCopy());

            _copyImageCommand = new DelegateCommand(
                p => _clipboardService.CopyImage());

            _zoomToFullExtentCommand = new DelegateCommand(
                p => _scatterplotService.ZoomToFullExtent());

            _clearLayoutCommand = new DelegateCommand(
                p => _layoutService.ClearLayout());
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

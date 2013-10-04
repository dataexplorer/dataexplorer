using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Presentation.Core.Commands;

namespace DataExplorer.Presentation.Views.ScatterPlots
{
    public class ScatterPlotContextMenuViewModel : IScatterPlotContextMenuViewModel
    {
        private readonly IScatterPlotService _service;
        private readonly IScatterPlotLayoutService _layoutService;

        public ScatterPlotContextMenuViewModel(
            IScatterPlotService service, 
            IScatterPlotLayoutService layoutService)
        {
            _service = service;
            _layoutService = layoutService;
        }

        public ICommand ZoomToFullExtentCommand
        {
            get { return new DelegateCommand(p => _service.ZoomToFullExtent()); }
        }

        public ICommand ClearLayoutCommand
        {
            get { return new DelegateCommand(p => _layoutService.ClearLayout());}
        }
    }
}

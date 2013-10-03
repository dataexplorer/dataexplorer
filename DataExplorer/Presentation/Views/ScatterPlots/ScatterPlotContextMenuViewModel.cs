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

        public ScatterPlotContextMenuViewModel(IScatterPlotService service)
        {
            _service = service;
        }

        public ICommand ZoomToFullExtentCommand
        {
            get { return new DelegateCommand(p => _service.ZoomToFullExtent()); }
        }
    }
}

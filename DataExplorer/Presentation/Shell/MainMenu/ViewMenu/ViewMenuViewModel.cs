using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Presentation.Core.Commands;

namespace DataExplorer.Presentation.Shell.MainMenu.ViewMenu
{
    public class ViewMenuViewModel : IViewMenuViewModel
    {
        private readonly IScatterPlotService _scatterPlotService;

        private readonly DelegateCommand _zoomExtentCommand;

        public ViewMenuViewModel(IScatterPlotService scatterPlotService)
        {
            _scatterPlotService = scatterPlotService;

            _zoomExtentCommand = new DelegateCommand(ZoomToFullExtent);
        }

        public ICommand ZoomToFullExtentCommand 
        {
            get { return _zoomExtentCommand; }
        }

        private void ZoomToFullExtent(object obj)
        {
            _scatterPlotService.ZoomToFullExtent();
        }
    }
}

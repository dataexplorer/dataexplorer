using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Presentation.Core.Commands;

namespace DataExplorer.Presentation.Shell.MainMenu.ViewMenu
{
    public class ViewMenuViewModel : IViewMenuViewModel
    {
        private readonly IScatterPlotService _scatterPlotService;
        private readonly IScatterPlotLayoutService _layoutService;

        public ViewMenuViewModel(
            IScatterPlotService scatterPlotService, 
            IScatterPlotLayoutService layoutService)
        {
            _scatterPlotService = scatterPlotService;
            _layoutService = layoutService;
        }

        public ICommand ZoomToFullExtentCommand 
        {
            get { return new DelegateCommand(p => _scatterPlotService.ZoomToFullExtent()); }
        }

        public ICommand ClearLayoutCommand
        {
            get { return new DelegateCommand(p => _layoutService.ClearLayout()); }
        }
    }
}

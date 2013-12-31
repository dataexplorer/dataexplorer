using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Presentation.Views.ScatterPlots.Scalers;

namespace DataExplorer.Presentation.Views.ScatterPlots.Commands
{
    public class ResizeScatterPlotViewExtentCommand : IResizeScatterPlotViewExtentCommand
    {
        private readonly IScatterPlotService _service;
        private readonly IViewResizer _resizer;

        public ResizeScatterPlotViewExtentCommand(
            IScatterPlotService service, 
            IViewResizer resizer)
        {
            _service = service;
            _resizer = resizer;
        }

        public void Execute(Size controlSize)
        {
            var viewExtent = _service.GetViewExtent();

            var newViewExtent = _resizer.ResizeView(controlSize, viewExtent);

            _service.SetViewExtent(newViewExtent);
        }
    }
}

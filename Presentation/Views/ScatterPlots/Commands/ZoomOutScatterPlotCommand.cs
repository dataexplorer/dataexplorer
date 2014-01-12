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
    public class ZoomOutScatterPlotCommand : IZoomOutScatterPlotCommand
    {
        private readonly IScatterPlotService _service;
        private readonly IPointScaler _scaler;

        public ZoomOutScatterPlotCommand(
            IScatterPlotService service, 
            IPointScaler scaler)
        {
            _service = service;
            _scaler = scaler;
        }
        
        public void Execute(Point center, Size controlSize)
        {
            var viewExtent = _service.GetViewExtent();

            var scaledCenter = _scaler.ScalePoint(center, controlSize, viewExtent);

            _service.ZoomOut(scaledCenter);
        }
    }
}

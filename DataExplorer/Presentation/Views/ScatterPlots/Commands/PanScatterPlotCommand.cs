using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Presentation.Views.ScatterPlots.Scalers;

namespace DataExplorer.Presentation.Views.ScatterPlots.Commands
{
    public class PanScatterPlotCommand : IPanScatterPlotCommand
    {
        private readonly IScatterPlotService _service;
        private readonly IVectorScaler _scaler;

        public PanScatterPlotCommand(
            IScatterPlotService service, 
            IVectorScaler scaler)
        {
            _service = service;
            _scaler = scaler;
        }

        public void Execute(Vector vector, Size controlSize)
        {
            var viewExtent = _service.GetViewExtent();

            var scaledVector = _scaler.ScaleVector(vector, controlSize, viewExtent);

            _service.Pan(scaledVector);
        }
    }
}

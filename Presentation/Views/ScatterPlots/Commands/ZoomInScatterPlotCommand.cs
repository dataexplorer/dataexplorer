using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Application.Views.ScatterPlots.Commands;
using DataExplorer.Application.Views.ScatterPlots.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.Scalers;

namespace DataExplorer.Presentation.Views.ScatterPlots.Commands
{
    public class ZoomInScatterPlotCommand : IZoomInScatterPlotCommand
    {
        private readonly IMessageBus _messageBus;
        private readonly IPointScaler _scaler;

        public ZoomInScatterPlotCommand(
            IMessageBus messageBus, 
            IPointScaler scaler)
        {
            _messageBus = messageBus;
            _scaler = scaler;
        }
        
        public void Execute(Point center, Size controlSize)
        {
            var viewExtent = _messageBus.Execute(new GetViewExtentQuery());

            var scaledCenter = _scaler.ScalePoint(center, controlSize, viewExtent);

            _messageBus.Execute(new ZoomInCommand(scaledCenter));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Views.ScatterPlots.Commands;
using DataExplorer.Application.Views.ScatterPlots.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.Scalers;

namespace DataExplorer.Presentation.Views.ScatterPlots.Commands
{
    public class ZoomOutScatterPlotCommand : IZoomOutScatterPlotCommand
    {
        private readonly IMessageBus _queryBus;
        private readonly IPointScaler _scaler;

        public ZoomOutScatterPlotCommand(
            IMessageBus queryBus, 
            IPointScaler scaler)
        {
            _queryBus = queryBus;
            _scaler = scaler;
        }
        
        public void Execute(Point center, Size controlSize)
        {
            var viewExtent = _queryBus.Execute(new GetViewExtentQuery());

            var scaledCenter = _scaler.ScalePoint(center, controlSize, viewExtent);

            _queryBus.Execute(new ZoomOutCommand(scaledCenter));
        }
    }
}

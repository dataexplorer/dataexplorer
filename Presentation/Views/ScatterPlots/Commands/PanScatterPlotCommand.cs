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
    public class PanScatterPlotCommand : IPanScatterPlotCommand
    {
        private readonly IMessageBus _messageBus;
        private readonly IVectorScaler _scaler;

        public PanScatterPlotCommand(
            IMessageBus messageBus, 
            IVectorScaler scaler)
        {
            _messageBus = messageBus;
            _scaler = scaler;
        }

        public void Execute(Vector vector, Size controlSize)
        {
            var viewExtent = _messageBus.Execute(new GetViewExtentQuery());

            var scaledVector = _scaler.ScaleVector(vector, controlSize, viewExtent);

            _messageBus.Execute(new PanCommand(scaledVector));
        }
    }
}

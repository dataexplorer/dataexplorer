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
    public class ResizeScatterPlotViewExtentCommand : IResizeScatterPlotViewExtentCommand
    {
        private readonly IMessageBus _messageBus;
        private readonly IViewResizer _resizer;

        public ResizeScatterPlotViewExtentCommand(
            IMessageBus messageBus, 
            IViewResizer resizer)
        {
            _messageBus = messageBus;
            _resizer = resizer;
        }

        public void Execute(Size controlSize)
        {
            var viewExtent = _messageBus.Execute(new GetViewExtentQuery());

            var newViewExtent = _resizer.ResizeView(controlSize, viewExtent);

            _messageBus.Execute(new SetViewExtentCommand(newViewExtent));
        }
    }
}

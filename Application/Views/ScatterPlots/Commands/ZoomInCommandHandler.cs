using System.Windows;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Domain.Core.Events;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Domain.Views.ScatterPlots.Events;

namespace DataExplorer.Application.Views.ScatterPlots.Commands
{
    public class ZoomInCommandHandler 
        : ICommandHandler<ZoomInCommand>
    {
        private const double ZoomInFactor = 0.1;

        private readonly IViewRepository _repository;

        public ZoomInCommandHandler(IViewRepository repository)
        {
            _repository = repository;
        }

        public void Execute(ZoomInCommand command)
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var viewExtent = scatterPlot.GetViewExtent();

            var x = viewExtent.X + (command.Center.X * ZoomInFactor) + (viewExtent.Width * ZoomInFactor) / 2;

            var y = viewExtent.Y + (command.Center.Y * ZoomInFactor) + (viewExtent.Height * ZoomInFactor) / 2;

            var width = viewExtent.Width - viewExtent.Width * ZoomInFactor;

            var height = viewExtent.Height - viewExtent.Height * ZoomInFactor;

            var zoomedViewExtent = new Rect(x, y, width, height);

            scatterPlot.SetViewExtent(zoomedViewExtent);

            DomainEvents.Raise(new ScatterPlotChangedEvent());
        }
    }
}

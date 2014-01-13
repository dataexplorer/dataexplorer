using System.Windows;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots.Commands
{
    public class ZoomOutCommandHandler : ICommandHandler<ZoomOutCommand>
    {
        private const double ZoomOutFactor = 0.11;

        private readonly IViewRepository _repository;

        public ZoomOutCommandHandler(IViewRepository repository)
        {
            _repository = repository;
        }

        public void Execute(ZoomOutCommand command)
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var viewExtent = scatterPlot.GetViewExtent();

            var x = viewExtent.X - (command.Center.X * ZoomOutFactor) - (viewExtent.Width * ZoomOutFactor) / 2;

            var y = viewExtent.Y - (command.Center.Y * ZoomOutFactor) - (viewExtent.Height * ZoomOutFactor) / 2;

            var width = viewExtent.Width + viewExtent.Width * ZoomOutFactor;

            var height = viewExtent.Height + viewExtent.Height * ZoomOutFactor;

            var zoomedViewExtent = new Rect(x, y, width, height);

            scatterPlot.SetViewExtent(zoomedViewExtent);

            DomainEvents.Raise(new ScatterPlotChangedEvent());
        }
    }
}

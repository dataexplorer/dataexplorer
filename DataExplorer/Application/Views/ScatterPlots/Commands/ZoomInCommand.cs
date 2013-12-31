using System.Windows;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots.Commands
{
    public class ZoomInCommand : IZoomInCommand
    {
        private const double ZoomInFactor = 0.1;

        private readonly IViewRepository _repository;

        public ZoomInCommand(IViewRepository repository)
        {
            _repository = repository;
        }

        public void ZoomIn(Point center)
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var viewExtent = scatterPlot.GetViewExtent();

            var x = viewExtent.X + (center.X * ZoomInFactor) + (viewExtent.Width * ZoomInFactor) / 2;

            var y = viewExtent.Y + (center.Y * ZoomInFactor) + (viewExtent.Height * ZoomInFactor) / 2;

            var width = viewExtent.Width - viewExtent.Width * ZoomInFactor;

            var height = viewExtent.Height - viewExtent.Height * ZoomInFactor;

            var zoomedViewExtent = new Rect(x, y, width, height);

            scatterPlot.SetViewExtent(zoomedViewExtent);

            DomainEvents.Raise(new ScatterPlotChangedEvent());
        }
    }
}

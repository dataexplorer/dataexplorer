using System.Windows;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Domain.Core.Events;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Domain.Views.ScatterPlots.Events;

namespace DataExplorer.Application.Views.ScatterPlots.Commands
{
    public class ZoomToFullExtentCommandHandler : ICommandHandler<ZoomToFullExtentCommand>
    {
        private const double DefaultZoom = 1.2d;
        private const double DefaultWorldX = 0d;
        private const double DefaultWorldY = 0d;
        private const double DefaultWorldWidth = 1d;
        private const double DefaultWorldHeight = 1d;
        private readonly IViewRepository _viewRepository;

        public ZoomToFullExtentCommandHandler(IViewRepository viewRepository)
        {
            _viewRepository = viewRepository;
        }

        public void Execute(ZoomToFullExtentCommand command)
        {
            var scatterPlot = _viewRepository.Get<ScatterPlot>();

            var viewExtent = scatterPlot.GetViewExtent();

            var aspectRatio = viewExtent.Width / viewExtent.Height;

            var width = aspectRatio > 1d
                ? DefaultZoom * aspectRatio
                : DefaultZoom;

            var height = aspectRatio > 1d
                ? DefaultZoom
                : DefaultZoom * (1d / aspectRatio);

            var x = DefaultWorldX - (width - DefaultWorldWidth) / 2;
            var y = DefaultWorldY - (height - DefaultWorldHeight) / 2;

            var newViewExtent = new Rect(x, y, width, height);

            scatterPlot.SetViewExtent(newViewExtent);

            DomainEvents.Raise(new ScatterPlotChangedEvent());
        }
    }
}

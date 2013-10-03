using System.Windows;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;

namespace DataExplorer.Application.ScatterPlots.Commands
{
    public class PanCommand : IPanCommand
    {
        private readonly IViewRepository _repository;

        public PanCommand(IViewRepository repository)
        {
            _repository = repository;
        }

        public void Pan(Vector vector)
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var viewExtent = scatterPlot.GetViewExtent();

            viewExtent.X += vector.X;

            viewExtent.Y += vector.Y;

            scatterPlot.SetViewExtent(viewExtent);

            DomainEvents.Raise(new ScatterPlotChangedEvent());
        }
    }
}

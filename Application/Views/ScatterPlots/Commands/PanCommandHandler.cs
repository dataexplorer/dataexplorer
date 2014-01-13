using System.Windows;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots.Commands
{
    public class PanCommandHandler 
        : ICommandHandler<PanCommand>
    {
        private readonly IViewRepository _repository;

        public PanCommandHandler(IViewRepository repository)
        {
            _repository = repository;
        }

        public void Execute(PanCommand command)
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var viewExtent = scatterPlot.GetViewExtent();

            viewExtent.X += command.Vector.X;

            viewExtent.Y += command.Vector.Y;

            scatterPlot.SetViewExtent(viewExtent);

            DomainEvents.Raise(new ScatterPlotChangedEvent());
        }
    }
}

using System.Windows;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots.Commands
{
    public class SetViewExtentCommandHandler 
        : ICommandHandler<SetViewExtentCommand>
    {
        private readonly IViewRepository _repository;

        public SetViewExtentCommandHandler(IViewRepository repository)
        {
            _repository = repository;
        }

        public void Execute(SetViewExtentCommand command)
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            scatterPlot.SetViewExtent(command.ViewExtent);
        }
    }
}

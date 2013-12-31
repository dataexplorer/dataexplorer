using System.Windows;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots.Commands
{
    public class SetViewExtentCommand : ISetViewExtentCommand
    {
        private readonly IViewRepository _repository;

        public SetViewExtentCommand(IViewRepository repository)
        {
            _repository = repository;
        }

        public void SetViewExtent(Rect viewExtent)
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            scatterPlot.SetViewExtent(viewExtent);
        }
    }
}

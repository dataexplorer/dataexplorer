using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots.Layouts.Commands
{
    public class ClearLayoutCommand : IClearLayoutCommand
    {
        private readonly IViewRepository _repository;

        public ClearLayoutCommand(IViewRepository repository)
        {
            _repository = repository;
        }

        public void Execute()
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            layout.Clear();
        }
    }
}

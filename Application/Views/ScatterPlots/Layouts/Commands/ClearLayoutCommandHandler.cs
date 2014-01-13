using DataExplorer.Application.Core.Commands;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots.Layouts.Commands
{
    public class ClearLayoutCommandHandler 
        : ICommandHandler<ClearLayoutCommand>
    {
        private readonly IViewRepository _repository;

        public ClearLayoutCommandHandler(IViewRepository repository)
        {
            _repository = repository;
        }

        public void Execute(ClearLayoutCommand command)
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            layout.Clear();
        }
    }
}

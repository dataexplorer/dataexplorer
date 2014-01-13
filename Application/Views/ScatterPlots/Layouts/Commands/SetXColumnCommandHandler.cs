using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots.Layouts.Commands
{
    public class SetXColumnCommandHandler 
        : ICommandHandler<SetXColumnCommand>
    {
        private readonly IColumnRepository _columnRepository;
        private readonly IViewRepository _viewRepository;

        public SetXColumnCommandHandler(
            IColumnRepository columnRepository,
            IViewRepository viewRepository)
        {
            _columnRepository = columnRepository;
            _viewRepository = viewRepository;
        }

        public void Execute(SetXColumnCommand command)
        {
            var column = _columnRepository.Get(command.Id);

            var scatterPlot = _viewRepository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            layout.XAxisColumn = column;
        }
    }
}

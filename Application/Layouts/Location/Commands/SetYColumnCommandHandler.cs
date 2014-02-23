using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Layouts.Location.Commands
{
    public class SetYColumnCommandHandler 
        : ICommandHandler<SetYColumnCommand>
    {
        private readonly IColumnRepository _columnRepository;
        private readonly IViewRepository _viewRepository;
        private readonly IEventBus _eventBus;

        public SetYColumnCommandHandler(
            IColumnRepository columnRepository, 
            IViewRepository viewRepository, 
            IEventBus eventBus)
        {
            _columnRepository = columnRepository;
            _viewRepository = viewRepository;
            _eventBus = eventBus;
        }

        public void Execute(SetYColumnCommand command)
        {
            var column = _columnRepository.Get(command.Id);

            var scatterPlot = _viewRepository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            layout.YAxisColumn = column;

            _eventBus.Raise(new LayoutChangedEvent());
        }
    }
}

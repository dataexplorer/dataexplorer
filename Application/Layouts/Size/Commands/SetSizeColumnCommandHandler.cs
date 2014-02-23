using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Layouts.Size.Commands;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Layouts.Size.Commands
{
    public class SetSizeColumnCommandHandler 
        : ICommandHandler<SetSizeColumnCommand>
    {
        private readonly IColumnRepository _columnRepository;
        private readonly IViewRepository _viewRepository;
        private readonly IEventBus _eventBus;

        public SetSizeColumnCommandHandler(
            IColumnRepository columnRepository, 
            IViewRepository viewRepository, 
            IEventBus eventBus)
        {
            _columnRepository = columnRepository;
            _viewRepository = viewRepository;
            _eventBus = eventBus;
        }

        public void Execute(SetSizeColumnCommand command)
        {
            var column = _columnRepository.Get(command.Id);

            var scatterPlot = _viewRepository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            layout.SizeColumn = column;

            _eventBus.Raise(new LayoutChangedEvent());
        }
    }
}

using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Layouts.Base.Commands;
using DataExplorer.Application.Views;

namespace DataExplorer.Application.Layouts.Location.Commands
{
    public class SetYAxisColumnCommandHandler
        : BaseSetLayoutColumnCommandHandler,
        ICommandHandler<SetYAxisColumnCommand>
    {
        public SetYAxisColumnCommandHandler(
            IColumnRepository columnRepository,
            IViewRepository viewRepository,
            IEventBus eventBus)
            : base(columnRepository, viewRepository, eventBus)
        {
        }

        public void Execute(SetYAxisColumnCommand command)
        {
            base.Execute(command.Id, (l, c) => l.YAxisColumn = c);
        }
    }
}

using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Layouts.Base.Commands;
using DataExplorer.Application.Views;

namespace DataExplorer.Application.Layouts.Location.Commands
{
    public class SetXAxisColumnCommandHandler
        : BaseSetLayoutColumnCommandHandler,
        ICommandHandler<SetXAxisColumnCommand>
    {
        public SetXAxisColumnCommandHandler(
            IColumnRepository columnRepository,
            IViewRepository viewRepository,
            IEventBus eventBus)
            : base(columnRepository, viewRepository, eventBus)
        {
        }

        public void Execute(SetXAxisColumnCommand command)
        {
            base.Execute(command.Id, (l, c) => l.XAxisColumn = c);
        }
    }
}

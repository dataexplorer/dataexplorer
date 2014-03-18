using System;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Layouts.Base.Commands;
using DataExplorer.Application.Views;

namespace DataExplorer.Application.Layouts.Color.Commands
{
    public class SetColorColumnCommandHandler
         : BaseSetLayoutColumnCommandHandler,
         ICommandHandler<SetColorColumnCommand>
    {
        public SetColorColumnCommandHandler(
            IColumnRepository columnRepository,
            IViewRepository viewRepository,
            IEventBus eventBus)
            : base(columnRepository, viewRepository, eventBus)
        {
        }

        public void Execute(SetColorColumnCommand command)
        {
            base.Execute(command.Id, (l, c) => l.ColorColumn = c);
        }
    }
}

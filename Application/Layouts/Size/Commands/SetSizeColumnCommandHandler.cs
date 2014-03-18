using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Layouts.Base.Commands;
using DataExplorer.Application.Views;

namespace DataExplorer.Application.Layouts.Size.Commands
{
    public class SetSizeColumnCommandHandler
        : BaseSetLayoutColumnCommandHandler,
        ICommandHandler<SetSizeColumnCommand>
    {
        public SetSizeColumnCommandHandler(
            IColumnRepository columnRepository,
            IViewRepository viewRepository,
            IEventBus eventBus)
            : base(columnRepository, viewRepository, eventBus)
        {
        }

        public void Execute(SetSizeColumnCommand command)
        {
            base.Execute(command.Id, (l, c) => l.SizeColumn = c);
        }
    }
}

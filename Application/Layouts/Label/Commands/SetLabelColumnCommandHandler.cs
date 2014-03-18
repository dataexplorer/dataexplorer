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

namespace DataExplorer.Application.Layouts.Label.Commands
{
    public class SetLabelColumnCommandHandler
         : BaseSetLayoutColumnCommandHandler,
         ICommandHandler<SetLabelColumnCommand>
    {
        public SetLabelColumnCommandHandler(
            IColumnRepository columnRepository,
            IViewRepository viewRepository,
            IEventBus eventBus)
            : base(columnRepository, viewRepository, eventBus)
        {
        }

        public void Execute(SetLabelColumnCommand command)
        {
            base.Execute(command.Id, (l, c) => l.LabelColumn = c);
        }
    }
}

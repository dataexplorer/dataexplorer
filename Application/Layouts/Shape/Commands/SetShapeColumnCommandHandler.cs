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

namespace DataExplorer.Application.Layouts.Shape.Commands
{
    public class SetShapeColumnCommandHandler 
        : BaseSetLayoutColumnCommandHandler,
        ICommandHandler<SetShapeColumnCommand>
    {
        public SetShapeColumnCommandHandler(
            IColumnRepository columnRepository, 
            IViewRepository viewRepository, 
            IEventBus eventBus) 
            : base(columnRepository, viewRepository, eventBus)
        {
        }

        public void Execute(SetShapeColumnCommand command)
        {
            base.Execute(command.Id, (l, c) => l.ShapeColumn = c);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Layouts.Base.Commands;
using DataExplorer.Application.Layouts.Color.Commands;
using DataExplorer.Application.Layouts.Color.Queries;
using DataExplorer.Application.Views;

namespace DataExplorer.Application.Layouts.Location.Commands
{
    public class SetColorSortOrderCommandHandler
           : BaseSetLayoutSortOrderCommandHandler,
           ICommandHandler<SetColorSortOrderCommand>
    {
        public SetColorSortOrderCommandHandler(
            IViewRepository repository,
            IEventBus eventBus)
            : base(repository, eventBus)
        {
        }

        public void Execute(SetColorSortOrderCommand command)
        {
            base.Execute((l, b) => l.ColorSortOrder = b, command.SortOrder);
        }
    }
}

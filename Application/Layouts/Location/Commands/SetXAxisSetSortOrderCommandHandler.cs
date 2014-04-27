using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Layouts.Base.Commands;
using DataExplorer.Application.Views;

namespace DataExplorer.Application.Layouts.Location.Commands
{
    public class SetXAxisSetSortOrderCommandHandler 
        : BaseSetLayoutSortOrderCommandHandler, 
        ICommandHandler<SetXAxisSetSortOrderCommand>
    {
        public SetXAxisSetSortOrderCommandHandler(
            IViewRepository repository, 
            IEventBus eventBus) 
            : base(repository, eventBus)
        {
        }

        public void Execute(SetXAxisSetSortOrderCommand command)
        {
            base.Execute((l, b) => l.XAxisSortOrder = b, command.SortOrder);
        }
    }
}

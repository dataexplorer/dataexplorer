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
    public class SetYAxisSetSortOrderCommandHandler 
        : BaseSetLayoutSortOrderCommandHandler,
        ICommandHandler<SetYAxisSetSortOrderCommand>
    {
        public SetYAxisSetSortOrderCommandHandler(
            IViewRepository repository, 
            IEventBus eventBus) 
            : base(repository, eventBus)
        {
        }

        public void Execute(SetYAxisSetSortOrderCommand command)
        {
            base.Execute((l, b) => l.YAxisSortOrder = b, command.SortOrder);
        }
    }
}

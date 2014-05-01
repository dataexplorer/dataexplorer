using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Layouts.Base.Commands;
using DataExplorer.Application.Views;

namespace DataExplorer.Application.Layouts.Size.Commands
{
    public class SetSizeSortOrderCommandHandler 
        : BaseSetLayoutSortOrderCommandHandler, 
        ICommandHandler<SetSizeSortOrderCommand>
    {
        public SetSizeSortOrderCommandHandler(
            IViewRepository repository, 
            IEventBus eventBus) 
            : base(repository, eventBus)
        {
        }

        public void Execute(SetSizeSortOrderCommand command)
        {
            base.Execute((l, b) => l.SizeSortOrder = b, command.SortOrder);
        }
    }
}

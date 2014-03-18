using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Layouts.Base.Commands;
using DataExplorer.Application.Views;

namespace DataExplorer.Application.Layouts.Link.Commands
{
    public class UnsetLinkColumnCommandHandler
        : BaseUnsetLayoutColumnCommandHandler,
        ICommandHandler<UnsetLinkColumnCommand>
    {
        public UnsetLinkColumnCommandHandler(
            IViewRepository viewRepository,
            IEventBus eventBus)
            : base(viewRepository, eventBus)
        {
        }

        public void Execute(UnsetLinkColumnCommand command)
        {
            base.Execute(layout => layout.LinkColumn = null);
        }
    }
}

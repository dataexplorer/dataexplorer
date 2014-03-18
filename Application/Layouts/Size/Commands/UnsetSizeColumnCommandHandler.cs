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
    public class UnsetSizeColumnCommandHandler
        : BaseUnsetLayoutColumnCommandHandler,
        ICommandHandler<UnsetSizeColumnCommand>
    {
        public UnsetSizeColumnCommandHandler(
            IViewRepository viewRepository,
            IEventBus eventBus)
            : base(viewRepository, eventBus)
        {
        }

        public void Execute(UnsetSizeColumnCommand command)
        {
            base.Execute(layout => layout.SizeColumn = null);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Layouts.Base.Commands;
using DataExplorer.Application.Views;

namespace DataExplorer.Application.Layouts.Color.Commands
{
    public class UnsetColorColumnCommandHandler
        : BaseUnsetLayoutColumnCommandHandler,
        ICommandHandler<UnsetColorColumnCommand>
    {
        public UnsetColorColumnCommandHandler(
            IViewRepository viewRepository,
            IEventBus eventBus)
            : base(viewRepository, eventBus)
        {
        }

        public void Execute(UnsetColorColumnCommand command)
        {
            base.Execute(layout => layout.ColorColumn = null);
        }
    }
}

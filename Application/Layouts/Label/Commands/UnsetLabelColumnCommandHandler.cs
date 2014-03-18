using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Layouts.Base.Commands;
using DataExplorer.Application.Views;

namespace DataExplorer.Application.Layouts.Label.Commands
{
    public class UnsetLabelColumnCommandHandler
         : BaseUnsetLayoutColumnCommandHandler,
         ICommandHandler<UnsetLabelColumnCommand>
    {
        public UnsetLabelColumnCommandHandler(
            IViewRepository viewRepository,
            IEventBus eventBus)
            : base(viewRepository, eventBus)
        {
        }

        public void Execute(UnsetLabelColumnCommand command)
        {
            base.Execute(layout => layout.LabelColumn = null);
        }
    }
}

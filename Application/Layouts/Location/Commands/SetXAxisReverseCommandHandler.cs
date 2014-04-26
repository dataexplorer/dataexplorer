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
    public class SetXAxisReverseCommandHandler 
        : BaseReverseLayoutCommandHandler, 
        ICommandHandler<SetXAxisReverseCommand>
    {
        public SetXAxisReverseCommandHandler(IViewRepository repository, IEventBus eventBus) 
            : base(repository, eventBus)
        {
        }

        public void Execute(SetXAxisReverseCommand command)
        {
            base.Execute((l, b) => l.XAxisReverse = b, command.IsReverse);
        }
    }
}

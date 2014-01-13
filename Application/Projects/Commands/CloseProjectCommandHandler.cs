using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Projects.Events;

namespace DataExplorer.Application.Projects.Commands
{
    public class CloseProjectCommandHandler 
        : ICommandHandler<CloseProjectCommand>
    {
        private readonly IDataContext _dataContext;
        private readonly IEventBus _eventBus;

        public CloseProjectCommandHandler(IDataContext dataContext, IEventBus eventBus)
        {
            _dataContext = dataContext;
            _eventBus = eventBus;
        }

        public void Execute(CloseProjectCommand command)
        {
            _dataContext.Clear();

            _eventBus.Raise(new ProjectClosedEvent());
        }
    }
}

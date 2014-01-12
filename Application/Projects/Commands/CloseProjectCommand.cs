using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.Projects;
using DataExplorer.Persistence;

namespace DataExplorer.Application.Projects.Commands
{
    public class CloseProjectCommand : ICloseProjectCommand
    {
        private readonly IDataContext _dataContext;
        private readonly IEventBus _eventBus;

        public CloseProjectCommand(IDataContext dataContext, IEventBus eventBus)
        {
            _dataContext = dataContext;
            _eventBus = eventBus;
        }

        public void Execute()
        {
            _dataContext.Clear();

            _eventBus.Raise(new ProjectClosedEvent());
        }
    }
}

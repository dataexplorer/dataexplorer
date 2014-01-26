using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
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
        private readonly IApplicationStateService _stateService;

        public CloseProjectCommandHandler(
            IEventBus eventBus, 
            IApplicationStateService stateService,
            IDataContext dataContext)
        {
            _dataContext = dataContext;
            _eventBus = eventBus;
            _stateService = stateService;
        }

        public void Execute(CloseProjectCommand command)
        {
            _eventBus.Raise(new ProjectClosingEvent());

            _stateService.ClearSelectedFilter();

            _stateService.ClearSelectedRows();

            _dataContext.Clear();

            _eventBus.Raise(new ProjectClosedEvent());
        }
    }
}

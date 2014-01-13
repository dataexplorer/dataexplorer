using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Rows.Events;

namespace DataExplorer.Application.Rows.Commands
{
    public class SetSelectedRowsCommandHandler 
        : ICommandHandler<SetSelectedRowsCommand>
    {
        private readonly IApplicationStateService _stateService;
        private readonly IEventBus _eventBus;

        public SetSelectedRowsCommandHandler(
            IApplicationStateService stateService, 
            IEventBus eventBus)
        {
            _stateService = stateService;
            _eventBus = eventBus;
        }

        public void Execute(SetSelectedRowsCommand command)
        {
            _stateService.SetSelectedRows(command.Rows.ToList());

            _eventBus.Raise(new SelectedRowsChangedEvent());
        }
    }
}

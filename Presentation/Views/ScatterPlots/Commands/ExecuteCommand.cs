using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;

namespace DataExplorer.Presentation.Views.ScatterPlots.Commands
{
    public class ExecuteCommand : IExecuteCommand
    {
        private readonly ICommandBus _commandBus;

        public ExecuteCommand(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        public void Execute(int id)
        {
            _commandBus.Execute(new Application.Views.ScatterPlots.Commands.ExecuteCommand(id));
        }
    }
}

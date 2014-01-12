using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;

namespace DataExplorer.Application.Application.Commands
{
    public class ExitCommandHandler : ICommandHandler<ExitCommand>
    {
        private readonly IApplication _application;

        public ExitCommandHandler(IApplication application)
        {
            _application = application;
        }

        public void Execute(ExitCommand command)
        {
            _application.ShutDown();
        }
    }
}

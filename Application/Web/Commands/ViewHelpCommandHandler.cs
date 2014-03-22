using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;

namespace DataExplorer.Application.Web.Commands
{
    public class ViewHelpCommandHandler
       : ICommandHandler<ViewHelpCommand>
    {
        private static readonly string ViewHelpPageUrl = "http://www.data-explorer.com/support/";

        private readonly IProcess _process;

        public ViewHelpCommandHandler(IProcess process)
        {
            _process = process;
        }

        public void Execute(ViewHelpCommand command)
        {
            _process.Start(ViewHelpPageUrl);
        }
    }
}

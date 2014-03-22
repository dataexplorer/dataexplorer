using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;

namespace DataExplorer.Application.Web.Commands
{
    public class ViewAboutCommandHandler
           : ICommandHandler<ViewAboutCommand>
    {
        private static readonly string ViewAboutPageUrl = "http://www.data-explorer.com/about/";

        private readonly IProcess _process;

        public ViewAboutCommandHandler(IProcess process)
        {
            _process = process;
        }

        public void Execute(ViewAboutCommand command)
        {
            _process.Start(ViewAboutPageUrl);
        }
    }
}

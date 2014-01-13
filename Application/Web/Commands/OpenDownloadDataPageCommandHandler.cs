using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;

namespace DataExplorer.Application.Web.Commands
{
    public class OpenDownloadDataPageCommandHandler 
        : ICommandHandler<OpenDownloadDataPageCommand>
    {
        private static readonly string DownloadDataPageUrl = "http://www.data-explorer.com/data/";

        private readonly IProcess _process;

        public OpenDownloadDataPageCommandHandler(IProcess process)
        {
            _process = process;
        }

        public void Execute(OpenDownloadDataPageCommand command)
        {
            _process.Start(DownloadDataPageUrl);
        }
    }
}

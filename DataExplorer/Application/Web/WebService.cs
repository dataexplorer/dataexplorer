using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Infrastructure.Process;

namespace DataExplorer.Application.Web
{
    public class WebService : IWebService
    {
        private static readonly string DownloadDataPageUrl = "http://www.data-explorer.com/data/";

        private readonly IProcess _process;

        public WebService(IProcess process)
        {
            _process = process;
        }

        public void LaunchDownloadDataPage()
        {
            _process.Start(DownloadDataPageUrl);
        }
    }
}

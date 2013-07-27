using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application;
using DataExplorer.Presentation.Shell.MainMenu.FileMenu;

namespace DataExplorer.Application
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplication _application;

        public ApplicationService(IApplication application)
        {
            _application = application;
        }

        public void Exit()
        {
            _application.ShutDown();
        }
    }
}

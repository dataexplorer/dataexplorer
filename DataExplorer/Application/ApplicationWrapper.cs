using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Application
{
    public class ApplicationWrapper : IApplication
    {
        public void ShutDown()
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}

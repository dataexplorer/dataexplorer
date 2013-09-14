using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Application.Application
{
    public interface IApplicationStateService
    {
        ApplicationState GetState();
    }
}

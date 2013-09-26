using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Events;

namespace DataExplorer.Application.Application
{
    public class ApplicationStateChangedEvent : IAppEvent
    {
        public ApplicationStateChangedEvent()
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Application.Core.Events
{
    public interface IEventBus
    {
        void Raise<T>(T args) where T : IAppEvent;
    }
}

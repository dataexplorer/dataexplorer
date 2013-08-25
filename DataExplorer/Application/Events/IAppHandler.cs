using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Application.Events
{
    public interface IAppHandler<T> where T : IAppEvent 
    {
        void Handle(T args);
    }
}

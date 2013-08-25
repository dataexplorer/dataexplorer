using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Events
{
    public interface IDomainHandler<T> where T : IDomainEvent
    {
        void Handle(T args);
    }
}

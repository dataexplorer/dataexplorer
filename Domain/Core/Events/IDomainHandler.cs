using System;

namespace DataExplorer.Domain.Core.Events
{
    public interface IDomainHandler<T> where T : IDomainEvent
    {
        void Handle(T args);
    }
}

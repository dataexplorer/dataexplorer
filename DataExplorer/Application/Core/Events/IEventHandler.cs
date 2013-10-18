namespace DataExplorer.Application.Core.Events
{
    public interface IEventHandler<T> where T : IEvent 
    {
        void Handle(T args);
    }
}

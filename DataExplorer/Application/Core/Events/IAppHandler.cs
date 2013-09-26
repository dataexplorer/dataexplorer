namespace DataExplorer.Application.Core.Events
{
    public interface IAppHandler<T> where T : IAppEvent 
    {
        void Handle(T args);
    }
}

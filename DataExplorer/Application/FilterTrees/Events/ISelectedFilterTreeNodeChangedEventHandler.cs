namespace DataExplorer.Application.FilterTrees.Events
{
    public interface ISelectedFilterTreeNodeChangedEventHandler
    {
        void Handle(SelectedFilterTreeNodeChangedEvent @event);
    }
}
namespace DataExplorer.Application.FilterTrees.Tasks
{
    public interface ISelectedFilterTreeNodeChangedEventHandler
    {
        void Handle(SelectedFilterTreeNodeChangedEvent @event);
    }
}
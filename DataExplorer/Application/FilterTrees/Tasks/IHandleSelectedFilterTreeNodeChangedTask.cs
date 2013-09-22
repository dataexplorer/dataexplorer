namespace DataExplorer.Application.FilterTrees.Tasks
{
    public interface IHandleSelectedFilterTreeNodeChangedTask
    {
        void Handle(SelectedFilterTreeNodeChangedEvent @event);
    }
}
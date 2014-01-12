namespace DataExplorer.Presentation.Panes.Property
{
    public interface IPropertyViewModel
    {
        string Name { get; }

        string Value { get; }
        
        bool IsLink { get; }
        
        void HandleLinkClick();
    }
}
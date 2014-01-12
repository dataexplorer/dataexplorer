namespace DataExplorer.Presentation.Dialogs.Open
{
    public interface IOpenFileDialog
    {
        void SetTitle(string title);
        
        void SetDefaultExtension(string extension);

        void SetFilter(string filter);

        bool? ShowDialog();

        string GetFilePath();
    }
}
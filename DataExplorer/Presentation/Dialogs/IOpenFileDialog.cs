namespace DataExplorer.Presentation.Dialogs
{
    public interface IOpenFileDialog
    {
        void SetDefaultExtension(string extension);
        void SetFilter(string filter);
        bool? ShowDialog();
        string GetFilePath();
    }
}
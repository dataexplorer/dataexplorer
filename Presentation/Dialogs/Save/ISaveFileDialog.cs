namespace DataExplorer.Presentation.Dialogs.Save
{
    public interface ISaveFileDialog
    {
        void SetTitle(string title);

        void SetDefaultExtension(string extension);

        void SetFilter(string filter);

        bool? ShowDialog();

        string GetFilePath();
    }
}

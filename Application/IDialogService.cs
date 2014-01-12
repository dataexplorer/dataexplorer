namespace DataExplorer.Application
{
    public interface IDialogService
    {
        void ShowImportDialog();

        string ShowOpenDialog();

        string ShowSaveDialog();

    }
}

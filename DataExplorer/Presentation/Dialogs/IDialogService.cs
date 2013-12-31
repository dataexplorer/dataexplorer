namespace DataExplorer.Presentation.Dialogs
{
    public interface IDialogService
    {
        void ShowImportDialog();

        string ShowOpenDialog();

        string ShowSaveDialog();

    }
}

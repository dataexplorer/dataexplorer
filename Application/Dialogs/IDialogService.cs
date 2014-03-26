using System;

namespace DataExplorer.Application
{
    public interface IDialogService
    {
        void ShowImportDialog();

        string ShowOpenDialog();

        string ShowSaveDialog();

        void ShowExceptionDialog(Exception ex);
    }
}

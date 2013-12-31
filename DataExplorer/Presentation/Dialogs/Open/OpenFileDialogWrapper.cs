using Microsoft.Win32;

namespace DataExplorer.Presentation.Dialogs.Open
{
    public class OpenFileDialogWrapper : IOpenFileDialog
    {
        private readonly OpenFileDialog _dialog;

        public OpenFileDialogWrapper()
        {
            _dialog = new OpenFileDialog();
        }

        public void SetTitle(string title)
        {
            _dialog.Title = title;
        }

        public void SetDefaultExtension(string extension)
        {
            _dialog.DefaultExt = extension;
        }

        public void SetFilter(string filter)
        {
            _dialog.Filter = filter;
        }
        
        public bool? ShowDialog()
        {
            return _dialog.ShowDialog();
        }

        public string GetFilePath()
        {
            return _dialog.FileName;
        }
    }
}

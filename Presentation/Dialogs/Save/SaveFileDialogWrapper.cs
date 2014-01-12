using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;


namespace DataExplorer.Presentation.Dialogs.Save
{
    public class SaveFileDialogWrapper : ISaveFileDialog
    {
       private readonly SaveFileDialog _dialog;

        public SaveFileDialogWrapper()
        {
            _dialog = new SaveFileDialog();
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

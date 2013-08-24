using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace DataExplorer.Presentation.Dialogs
{
    public class OpenFileDialogWrapper : IOpenFileDialog
    {
        private readonly OpenFileDialog _dialog;

        public OpenFileDialogWrapper()
        {
            _dialog = new OpenFileDialog();
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

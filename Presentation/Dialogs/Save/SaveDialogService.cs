using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DataExplorer.Presentation.Dialogs.Save
{
    public class SaveDialogService : ISaveDialogService
    {
        private const string SaveDialogTitle = "Save";
        private const string DefaultFileExtension = ".xml";
        private const string FileFilter = "Data Explorer Projects|*.xml";

        private readonly IDialogFactory _factory;

        public SaveDialogService(IDialogFactory factory)
        {
            _factory = factory;
        }

        public string Show()
        {
            if (Dispatcher.CurrentDispatcher.Thread.IsBackground)
                return Dispatcher.CurrentDispatcher.Invoke((Func<string>) Show);

            var dialog = _factory.CreateSaveFileDialog();
            dialog.SetTitle(SaveDialogTitle);
            dialog.SetDefaultExtension(DefaultFileExtension);
            dialog.SetFilter(FileFilter);

            var result = dialog.ShowDialog();

            if (!result.HasValue || !result.Value)
                return null;

            var filePath = dialog.GetFilePath();

            return filePath;
        }
    }
}

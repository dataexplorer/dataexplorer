using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using DataExplorer.Application.Application;

namespace DataExplorer.Presentation.Dialogs.Open
{
    public class OpenDialogService : IOpenDialogService
    {
        private const string OpenDialogTitle = "Open";
        private const string DefaultFileExtension = ".xml";
        private const string FileFilter = "Data Explorer Projects|*.xml";

        private readonly IDialogFactory _factory;

        public OpenDialogService(IDialogFactory factory)
        {
            _factory = factory;
        }

        public string Show()
        {
            if (Dispatcher.CurrentDispatcher.Thread.IsBackground)
                return Dispatcher.CurrentDispatcher.Invoke((Func<string>) Show);

            var dialog = _factory.CreateOpenFileDialog();
            dialog.SetTitle(OpenDialogTitle);
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

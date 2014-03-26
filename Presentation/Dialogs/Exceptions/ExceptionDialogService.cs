using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace DataExplorer.Presentation.Dialogs.Exceptions
{
    public class ExceptionDialogService : IExceptionDialogService
    {
        private const string ExceptionDialogTitle = "Data Explorer Error";
        private const string ExceptionMessage = "Sorry, but Data Explorer has encountered an unhandled exception.  Please send the information below to support@data-explorer.com and restart the application.";
       
        private readonly IDialogFactory _factory;

        public ExceptionDialogService(
            IDialogFactory factory)
        {
            _factory = factory;
        }

        public void Show(Exception ex)
        {
            if (Dispatcher.CurrentDispatcher.Thread.IsBackground)
            {
                Dispatcher.CurrentDispatcher.Invoke(() => Show(ex));
                return;
            }

            var dialog = _factory.CreateExceptionDialog();
            //dialog.SetOwner(_application.GetMainWindow());
            dialog.SetStartupLocation(WindowStartupLocation.CenterScreen);
            dialog.SetIcon(SystemIcons.Error);
            dialog.SetTitle(ExceptionDialogTitle);
            dialog.SetMessage(ExceptionMessage);
            dialog.SetException(ex);

            dialog.ShowDialog();
        }
    }
}

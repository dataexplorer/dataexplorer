using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataExplorer.Presentation.Dialogs.Exceptions
{
    public interface IExceptionDialog
    {
        void SetStartupLocation(WindowStartupLocation location);

        void SetIcon(Icon icon);

        void SetTitle(string title);

        void SetMessage(string message);

        void SetException(Exception ex);
        
        void ShowDialog();
    }
}

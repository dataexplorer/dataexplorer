using System.Windows;

namespace DataExplorer.Presentation.Core.Services
{
    public class WindowService : IWindowService
    {
        public Window GetMainWindow()
        {
            return System.Windows.Application.Current.MainWindow;
        }
    }
}

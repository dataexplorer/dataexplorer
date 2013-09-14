using System.Windows;

namespace DataExplorer.Infrastructure.Application
{
    public class ApplicationWrapper : IApplication
    {
        public Window GetMainWindow()
        {
            return System.Windows.Application.Current.MainWindow;
        }

        public void ShutDown()
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}

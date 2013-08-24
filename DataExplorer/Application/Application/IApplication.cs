using System.Windows;

namespace DataExplorer.Application.Application
{
    public interface IApplication
    {
        Window GetMainWindow();

        void ShutDown();
    }
}

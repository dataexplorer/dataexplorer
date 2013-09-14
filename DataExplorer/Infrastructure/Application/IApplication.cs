using System.Windows;

namespace DataExplorer.Infrastructure.Application
{
    public interface IApplication
    {
        Window GetMainWindow();

        void ShutDown();
    }
}

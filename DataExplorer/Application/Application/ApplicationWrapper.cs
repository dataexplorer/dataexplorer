namespace DataExplorer.Application.Application
{
    public class ApplicationWrapper : IApplication
    {
        public void ShutDown()
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}

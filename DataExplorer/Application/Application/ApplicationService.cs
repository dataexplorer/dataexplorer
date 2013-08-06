namespace DataExplorer.Application.Application
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplication _application;

        public ApplicationService(IApplication application)
        {
            _application = application;
        }

        public void Exit()
        {
            _application.ShutDown();
        }
    }
}

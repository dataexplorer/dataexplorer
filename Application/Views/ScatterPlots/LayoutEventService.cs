using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Events;

namespace DataExplorer.Application.Views.ScatterPlots
{
    public class LayoutEventService : 
        IEventHandler<ProjectOpenedEvent>,
        IEventHandler<ProjectClosedEvent>,
        IEventHandler<CsvFileImportedEvent>
    {
        private readonly IEventBus _eventBus;

        public LayoutEventService(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void Handle(ProjectOpenedEvent args)
        {
            _eventBus.Raise(new LayoutResetEvent());
        }

        public void Handle(ProjectClosedEvent args)
        {
            _eventBus.Raise(new LayoutResetEvent());
        }

        public void Handle(CsvFileImportedEvent args)
        {
            _eventBus.Raise(new LayoutResetEvent());
        }
    }
}

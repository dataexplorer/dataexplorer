using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Application.Views.ScatterPlots.Events;

namespace DataExplorer.Application.Views.ScatterPlots
{
    public class ScatterPlotLayoutEventService : 
        IEventHandler<ProjectOpenedEvent>,
        IEventHandler<ProjectClosedEvent>,
        IEventHandler<CsvFileImportedEvent>
    {
        private readonly IEventBus _eventBus;

        public ScatterPlotLayoutEventService(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void Handle(ProjectOpenedEvent args)
        {
            _eventBus.Raise(new ScatterPlotLayoutChangedEvent());
        }

        public void Handle(ProjectClosedEvent args)
        {
            _eventBus.Raise(new ScatterPlotLayoutChangedEvent());
        }

        public void Handle(CsvFileImportedEvent args)
        {
            _eventBus.Raise(new ScatterPlotLayoutChangedEvent());
        }
    }
}

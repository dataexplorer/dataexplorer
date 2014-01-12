using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Filters.Events;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Application.Views.ScatterPlots.Commands;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots
{
    public class ScatterPlotEventsService 
        : IEventHandler<ProjectOpenedEvent>,
        IEventHandler<ProjectClosedEvent>,
        IDomainHandler<ScatterPlotLayoutColumnChangedEvent>,
        IEventHandler<CsvFileImportedEvent>,
        IEventHandler<FilterChangedEvent>
    {
        private readonly IUpdatePlotsCommand _updateCommand;

        public ScatterPlotEventsService(IUpdatePlotsCommand updateCommand)
        {
            _updateCommand = updateCommand;
        }

        public void Handle(ProjectOpenedEvent args)
        {
            _updateCommand.UpdatePlots();
        }

        public void Handle(ProjectClosedEvent args)
        {
            _updateCommand.UpdatePlots();
        }

        public void Handle(ScatterPlotLayoutColumnChangedEvent args)
        {
            _updateCommand.UpdatePlots();
        }

        public void Handle(CsvFileImportedEvent args)
        {
            _updateCommand.UpdatePlots();
        }

        public void Handle(FilterChangedEvent args)
        {
            _updateCommand.UpdatePlots();
        }
    }
}

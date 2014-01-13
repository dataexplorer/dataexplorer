using DataExplorer.Application.Core.Commands;
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
        private readonly ICommandBus _commandBus;

        public ScatterPlotEventsService(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        public void Handle(ProjectOpenedEvent args)
        {
            _commandBus.Execute(new UpdatePlotsCommand());
        }

        public void Handle(ProjectClosedEvent args)
        {
            _commandBus.Execute(new UpdatePlotsCommand());
        }

        public void Handle(ScatterPlotLayoutColumnChangedEvent args)
        {
            _commandBus.Execute(new UpdatePlotsCommand());
        }

        public void Handle(CsvFileImportedEvent args)
        {
            _commandBus.Execute(new UpdatePlotsCommand());
        }

        public void Handle(FilterChangedEvent args)
        {
            _commandBus.Execute(new UpdatePlotsCommand());
        }
    }
}

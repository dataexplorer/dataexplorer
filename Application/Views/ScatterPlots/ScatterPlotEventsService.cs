using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Filters.Events;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Layouts.Events;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Application.Views.ScatterPlots.Commands;


namespace DataExplorer.Application.Views.ScatterPlots
{
    public class ScatterPlotEventsService 
        : IEventHandler<ProjectOpenedEvent>,
        IEventHandler<ProjectClosedEvent>,
        IEventHandler<LayoutChangedEvent>,
        IEventHandler<SourceImportedEvent>,
        IEventHandler<FilterAddedEvent>,
        IEventHandler<FilterRemovedEvent>,
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

        public void Handle(LayoutChangedEvent args)
        {
            _commandBus.Execute(new UpdatePlotsCommand());
        }

        public void Handle(SourceImportedEvent args)
        {
            _commandBus.Execute(new UpdatePlotsCommand());
        }

        public void Handle(FilterAddedEvent args)
        {
            _commandBus.Execute(new UpdatePlotsCommand());
        }

        public void Handle(FilterRemovedEvent args)
        {
            _commandBus.Execute(new UpdatePlotsCommand());
        }

        public void Handle(FilterChangedEvent args)
        {
            _commandBus.Execute(new UpdatePlotsCommand());
        }
    }
}

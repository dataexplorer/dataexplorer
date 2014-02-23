using System;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Layouts.Color.Commands
{
    public class SetColorPaletteCommandHandler : ICommandHandler<SetColorPaletteCommand>
    {
        private readonly IViewRepository _repository;
        private readonly IEventBus _eventBus;

        public SetColorPaletteCommandHandler(
            IViewRepository repository, 
            IEventBus eventBus)
        {
            _repository = repository;
            _eventBus = eventBus;
        }

        public void Execute(SetColorPaletteCommand command)
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            layout.ColorPalette = command.Entity;

            _eventBus.Raise(new LayoutChangedEvent());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots.Layouts.Commands
{
    public class SetColorPaletteCommandHandler : ICommandHandler<SetColorPaletteCommand>
    {
        private readonly IViewRepository _repository;

        public SetColorPaletteCommandHandler(IViewRepository repository)
        {
            _repository = repository;
        }

        public void Execute(SetColorPaletteCommand command)
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            layout.ColorPalette = command.Entity;
        }
    }
}

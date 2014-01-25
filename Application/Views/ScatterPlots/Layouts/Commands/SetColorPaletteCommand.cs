using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Domain;

namespace DataExplorer.Application.Views.ScatterPlots.Layouts.Commands
{
    public class SetColorPaletteCommand : EntityCommand<ColorPalette>
    {
        public SetColorPaletteCommand(ColorPalette entity) : base(entity)
        {
        }
    }
}

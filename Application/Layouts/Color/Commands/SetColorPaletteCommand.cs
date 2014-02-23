using System;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Domain.Colors;

namespace DataExplorer.Application.Layouts.Color.Commands
{
    public class SetColorPaletteCommand : EntityCommand<ColorPalette>
    {
        public SetColorPaletteCommand(ColorPalette entity) : base(entity)
        {
        }
    }
}

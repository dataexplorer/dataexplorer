using System;
using System.Collections.Generic;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Domain.Colors;

namespace DataExplorer.Application.Layouts.Color.Queries
{
    public class GetAllColorPalettesQueryHandler 
        : IQueryHandler<GetAllColorPalettesQuery, List<ColorPalette>>
    {
        private readonly IColorPaletteFactory _colorPaletteFactory;

        public GetAllColorPalettesQueryHandler(IColorPaletteFactory colorPaletteFactory)
        {
            _colorPaletteFactory = colorPaletteFactory;
        }

        public List<ColorPalette> Execute(GetAllColorPalettesQuery query)
        {
            var colorPalettes = _colorPaletteFactory.GetColorPalettes();

            return colorPalettes;
        }
    }
}

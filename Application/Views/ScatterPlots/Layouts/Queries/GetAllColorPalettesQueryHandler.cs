using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Domain;
using DataExplorer.Domain.Colors;

namespace DataExplorer.Application.Views.ScatterPlots.Layouts.Queries
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

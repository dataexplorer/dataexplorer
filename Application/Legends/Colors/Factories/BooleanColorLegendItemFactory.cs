using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Maps.ColorMaps;

namespace DataExplorer.Application.Legends.Colors.Factories
{
    public class BooleanColorLegendItemFactory : IBooleanColorLegendFactory
    {
        public IEnumerable<ColorLegendItemDto> Create(ColorMap map, List<bool> values, ColorPalette palette)
        {
            yield return CreateColorLegendItem(map, false, palette.Colors.First());

            yield return CreateColorLegendItem(map, true, palette.Colors.Last());
        }

        private static ColorLegendItemDto CreateColorLegendItem(ColorMap map, bool value, Color color)
        {
            var itemDto = new ColorLegendItemDto()
            {
                Color = color,
                Label = value.ToString()
            };

            return itemDto;
        }
    }
}

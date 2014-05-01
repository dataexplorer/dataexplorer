using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Maps.ColorMaps;

namespace DataExplorer.Application.Legends.Colors.Factories
{
    public class BooleanColorLegendFactory 
        : BaseColorLegendFactory,
        IBooleanColorLegendFactory
    {
        public IEnumerable<ColorLegendItemDto> Create(ColorMap map, List<bool?> values, ColorPalette palette)
        {
            if (values.Contains(null))
                yield return CreateNullColorLegendItem();

            if (map.SortOrder == SortOrder.Ascending)
            {
                yield return CreateColorLegendItem("False", palette.Colors.First());

                yield return CreateColorLegendItem("True", palette.Colors.Last());    
            }
            else
            {
                yield return CreateColorLegendItem("True", palette.Colors.First());

                yield return CreateColorLegendItem("False", palette.Colors.Last());
            }
        }

        private static ColorLegendItemDto CreateColorLegendItem(string label, Color color)
        {
            var itemDto = new ColorLegendItemDto()
            {
                Color = color,
                Label = label
            };

            return itemDto;
        }
    }
}

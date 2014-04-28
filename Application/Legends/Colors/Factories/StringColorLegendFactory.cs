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
    public class StringColorLegendFactory 
        : BaseColorLegendFactory,
        IStringColorLegendFactory
    {
        public IEnumerable<ColorLegendItemDto> Create(ColorMap map, List<string> values, ColorPalette palette)
        {
            if (values.Any(p => p == null))
                yield return CreateNullColorLegendItem();

            var distinctValues = values
                .Distinct()
                .ToList();

            var nonNullValues = distinctValues
                .Where(p => p != null)
                .ToList();

            var results = (distinctValues.Count() <= palette.Colors.Count())
                ? CreateDiscreteColorLegendItems(map, nonNullValues)
                : CreateContinuousColorLegendItems(map, palette);

            foreach (var result in results)
                yield return result;
        }
        
        private IEnumerable<ColorLegendItemDto> CreateDiscreteColorLegendItems(ColorMap map, List<string> values)
        {
            if (map.SortOrder == SortOrder.Descending)
                values.Reverse();

            for (var i = 0; i < values.Count(); i++)
            {
                var itemDto = new ColorLegendItemDto()
                {
                    Color = map.Map(values[i]),
                    Label = values[i]
                };

                yield return itemDto;
            }
        }

        private IEnumerable<ColorLegendItemDto> CreateContinuousColorLegendItems(ColorMap map, ColorPalette palette)
        {
            for (var i = 0; i < palette.Colors.Count(); i++)
            {
                var itemDto = new ColorLegendItemDto()
                {
                    Color = palette.Colors[i],
                    Label = (string) map.MapInverse(palette.Colors[i])
                };

                yield return itemDto;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Maps.ColorMaps;

namespace DataExplorer.Application.Legends.Colors.Factories
{
    public class IntegerColorLegendFactory 
        : BaseColorLegendFactory,
        IIntegerColorLegendFactory
    {
        public IEnumerable<ColorLegendItemDto> Create(ColorMap map, List<int?> values, ColorPalette palette)
        {
            if (values.Any(p => p.HasValue == false))
                yield return CreateNullColorLegendItem();

            var nonNullValues = values
                .Where(p => p.HasValue)
                .Cast<int>()
                .ToList();

            var results = (values.Count() <= palette.Colors.Count())
                ? CreateDiscreteColorLegendItems(map, nonNullValues)
                : CreateContinuousColorLegendItems(map, palette);

            foreach (var result in results)
                yield return result;
        }
        
        private IEnumerable<ColorLegendItemDto> CreateDiscreteColorLegendItems(ColorMap map, List<int> values)
        {
            for (var i = 0; i < values.Count(); i++)
            {
                var itemDto = new ColorLegendItemDto()
                {
                    Color = map.Map(values[i]),
                    Label = GetLabelName(values[i])
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
                    Label = GetLabelName((int) map.MapInverse(palette.Colors[i]))
                };

                yield return itemDto;
            }
        }

        // TODO: Need to Refactor to a common location
        private string GetLabelName(int value)
        {
            if (value <= -1000000 || value >= 1000000)
                return value.ToString("E2");

            return value.ToString();
        }
    }
}

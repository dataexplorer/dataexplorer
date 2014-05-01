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
    public class DateTimeColorLegendFactory 
        : BaseColorLegendFactory,
        IDateTimeColorLegendFactory
    {
        public IEnumerable<ColorLegendItemDto> Create(ColorMap map, List<DateTime?> values, ColorPalette palette)
        {
            if (values.Any(p => p.HasValue == false))
                yield return CreateNullColorLegendItem();

            var nonNullValues = values
                .Where(p => p.HasValue)
                .Cast<DateTime>()
                .ToList();

            var results = (values.Count() <= palette.Colors.Count())
                ? CreateDiscreteColorLegendItems(map, nonNullValues)
                : CreateContinuousColorLegendItems(map, palette);

            foreach (var result in results)
                yield return result;
        }
        
        private IEnumerable<ColorLegendItemDto> CreateDiscreteColorLegendItems(ColorMap map, List<DateTime> values)
        {
            if (map.SortOrder == SortOrder.Descending)
                values.Reverse();

            for (var i = 0; i < values.Count(); i++)
            {
                var itemDto = new ColorLegendItemDto()
                {
                    Color = map.Map(values[i]),
                    Label = values[i].ToShortDateString()
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
                    Label = ((DateTime) map.MapInverse(palette.Colors[i])).ToShortDateString()
                };

                yield return itemDto;
            }
        }
    }
}

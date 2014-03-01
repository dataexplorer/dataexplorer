using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Maps.SizeMaps;

namespace DataExplorer.Application.Legends.Sizes.Factories
{
    public class DateTimeSizeLegendFactory 
        : BaseSizeLegendFactory,
        IDateTimeSizeLegendFactory
    {
        public IEnumerable<SizeLegendItemDto> Create(SizeMap map, List<DateTime?> values, double lowerSize, double upperSize)
        {
            if (values.Any(p => p.HasValue == false))
                yield return CreateNullSizeLegendItem();

            var nonNullValues = values
                .Where(p => p.HasValue)
                .Cast<DateTime>()
                .ToList();

            var results = (values.Count() <= MaxDiscreteValues)
                ? CreateDiscreteSizeLegendItems(map, nonNullValues)
                : CreateContinuousSizeLegendItems(map, lowerSize, upperSize);

            foreach (var result in results)
                yield return result;
        }

        private IEnumerable<SizeLegendItemDto> CreateDiscreteSizeLegendItems(SizeMap map, List<DateTime> values)
        {
            for (var i = 0; i < values.Count(); i++)
            {
                var itemDto = new SizeLegendItemDto()
                {
                    Size = map.Map(values[i]).GetValueOrDefault(),
                    Label = values[i].ToShortDateString()
                };

                yield return itemDto;
            }
        }

        private IEnumerable<SizeLegendItemDto> CreateContinuousSizeLegendItems(SizeMap map, double lowerSize, double upperSize)
        {
            var unit = (upperSize - lowerSize) / 2;

            for (var i = 0; i < ContinuousItems; i++)
            {
                var itemDto = new SizeLegendItemDto()
                {
                    Size = lowerSize + (unit * i),
                    Label = ((DateTime) map.MapInverse(i * 0.5d)).ToShortDateString()
                };

                yield return itemDto;
            }
        }
    }
}

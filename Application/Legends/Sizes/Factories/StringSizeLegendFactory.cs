using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Maps.SizeMaps;

namespace DataExplorer.Application.Legends.Sizes.Factories
{
    public class StringSizeLegendFactory
        : BaseSizeLegendFactory,
        IStringSizeLegendFactory
    {
        public IEnumerable<SizeLegendItemDto> Create(SizeMap map, List<string> values, double lowerSize, double upperSize)
        {
            if (values.Any(p => p == null))
                yield return CreateNullSizeLegendItem();

            var nonNullValues = values
                .Where(p => p != null)
                .ToList();

            var results = (values.Count() <= MaxDiscreteValues)
                ? CreateDiscreteSizeLegendItems(map, nonNullValues)
                : CreateContinuousSizeLegendItems(map, lowerSize, upperSize);

            foreach (var result in results)
                yield return result;
        }

        private IEnumerable<SizeLegendItemDto> CreateDiscreteSizeLegendItems(SizeMap map, List<string> values)
        {
            for (var i = 0; i < values.Count(); i++)
            {
                var itemDto = new SizeLegendItemDto()
                {
                    Size = map.Map(values[i]).GetValueOrDefault(),
                    Label = values[i]
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
                    Label = (string) map.MapInverse(i * 0.5d)
                };

                yield return itemDto;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Maps.SizeMaps;

namespace DataExplorer.Application.Legends.Sizes.Factories
{
    public class FloatSizeLegendFactory 
        : BaseSizeLegendFactory, 
        IFloatSizeLegendFactory
    {
        public IEnumerable<SizeLegendItemDto> Create(SizeMap map, List<double?> values, double lowerSize, double upperSize)
        {
            if (values.Any(p => p.HasValue == false))
                yield return CreateNullSizeLegendItem();

            var nonNullValues = values
                .Where(p => p.HasValue)
                .Cast<double>()
                .ToList();

            var results = (values.Count() <= MaxDiscreteValues)
                ? CreateDiscreteSizeLegendItems(map, nonNullValues)
                : CreateContinuousSizeLegendItems(map, lowerSize, upperSize);

            foreach (var result in results)
                yield return result;
        }

        private IEnumerable<SizeLegendItemDto> CreateDiscreteSizeLegendItems(SizeMap map, List<double> values)
        {
            if (map.SortOrder == SortOrder.Descending)
                values.Reverse();

            for (var i = 0; i < values.Count(); i++)
            {
                var itemDto = new SizeLegendItemDto()
                {
                    Size = map.Map(values[i]).GetValueOrDefault(),
                    Label = GetLabelName(values[i])
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
                    Size = lowerSize + (i * unit),
                    Label = GetLabelName((double?) map.MapInverse(i * unit))
                };

                yield return itemDto;
            }
        }

        // TODO: Need to refactor to common class
        private string GetLabelName(double? value)
        {
            if (!value.HasValue)
                return "N/A";

            if (value <= -1000000d || value >= 1000000d
                || (value >= -0.001d && value <= 0.001d && value != 0d))
                return value.Value.ToString("E2");

            return value.Value.ToString("N2");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Maps.SizeMaps;

namespace DataExplorer.Application.Legends.Sizes.Factories
{
    public class BooleanSizeLegendFactory 
        : BaseSizeLegendFactory, 
        IBooleanSizeLegendFactory
    {
        public IEnumerable<SizeLegendItemDto> Create(SizeMap map, List<bool?> values, double lowerSize, double upperSize)
        {
            if (values.Contains(null))
                yield return CreateNullSizeLegendItem();

            if (map.SortOrder == SortOrder.Ascending)
            {
                yield return CreateSizeLegendItem("False", lowerSize);

                yield return CreateSizeLegendItem("True", upperSize);    
            }
            else
            {
                yield return CreateSizeLegendItem("True", lowerSize);

                yield return CreateSizeLegendItem("False", upperSize);
            }
            
        }

        private static SizeLegendItemDto CreateSizeLegendItem(string label, double size)
        {
            var itemDto = new SizeLegendItemDto()
            {
                Size = size,
                Label = label
            };

            return itemDto;
        }
    }
}

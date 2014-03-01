using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Maps.SizeMaps;

namespace DataExplorer.Application.Legends.Sizes.Factories
{
    public class IntegerSizeLegendFactory
        : BaseSizeLegendFactory,
        IIntegerSizeLegendFactory
    {
        public List<SizeLegendItemDto> Create(SizeMap map, List<int?> values, double lowerSize, double upperSize)
        {
            throw new NotImplementedException();
        }
    }
}

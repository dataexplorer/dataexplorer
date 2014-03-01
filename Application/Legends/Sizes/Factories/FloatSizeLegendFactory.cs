using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Maps.SizeMaps;

namespace DataExplorer.Application.Legends.Sizes.Factories
{
    public class FloatSizeLegendFactory 
        : BaseSizeLegendFactory, 
        IFloatSizeLegendFactory
    {
        public List<SizeLegendItemDto> Create(SizeMap map, List<double?> values, double lowerSize, double upperSize)
        {
            throw new NotImplementedException();
        }
    }
}

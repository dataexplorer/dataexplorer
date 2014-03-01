using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Maps.SizeMaps;

namespace DataExplorer.Application.Legends.Sizes.Factories
{
    public interface IFloatSizeLegendFactory
    {
        IEnumerable<SizeLegendItemDto> Create(SizeMap map, List<double?> values, double lowerSize, double upperSize);
    }
}

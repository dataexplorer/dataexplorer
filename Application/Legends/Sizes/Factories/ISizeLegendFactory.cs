using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Maps.SizeMaps;

namespace DataExplorer.Application.Legends.Sizes.Factories
{
    public interface ISizeLegendFactory
    {
        IEnumerable<SizeLegendItemDto> Create(Type type, SizeMap map, List<object> values, double lowerSize, double upperSize);
    }
}

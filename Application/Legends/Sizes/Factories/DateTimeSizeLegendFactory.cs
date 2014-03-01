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
        public List<SizeLegendItemDto> Create(SizeMap map, List<DateTime?> values, double lowerSize, double upperSize)
        {
            throw new NotImplementedException();
        }
    }
}

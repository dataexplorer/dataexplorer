using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Application.Legends.Sizes.Factories
{
    public abstract class BaseSizeLegendFactory
    {
        protected const int MaxDiscreteValues = 4;
        protected const int ContinuousItems = 3;
        private static readonly double NullSize = 0d;

        protected SizeLegendItemDto CreateNullSizeLegendItem()
        {
            var itemDto = new SizeLegendItemDto()
            {
                Size = NullSize,
                Label = "Null"
            };

            return itemDto;
        }
    }
}

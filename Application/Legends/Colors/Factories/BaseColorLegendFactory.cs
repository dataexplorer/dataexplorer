using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Maps.ColorMaps;

namespace DataExplorer.Application.Legends.Colors.Factories
{
    public abstract class BaseColorLegendFactory
    {
        private static readonly Color NullColor = new Color(127, 127, 127);
        
        protected ColorLegendItemDto CreateNullColorLegendItem()
        {
            var itemDto = new ColorLegendItemDto()
            {
                Color = NullColor,
                Label = "Null"
            };

            return itemDto;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Layouts;

namespace DataExplorer.Domain.Maps.ColorMaps
{
    public class BooleanToColorMap : ColorMap
    {
        private readonly List<Color> _colors;

        public BooleanToColorMap(List<Color> colors, SortOrder sortOrder) 
            : base(sortOrder)
        {
            _colors = colors;
        }

        public override Color Map(object value)
        {
            if (value == null)
                return NullColor;

            return _sortOrder == SortOrder.Ascending
                ? ((bool) value
                    ? _colors.Last()
                    : _colors.First())
                : ((bool) value
                    ? _colors.First()
                    : _colors.Last());
        }

        public override object MapInverse(Color value)
        {
            if (value.Equals(_colors.First()))
                return false;
            
            return true;
        }
    }
}

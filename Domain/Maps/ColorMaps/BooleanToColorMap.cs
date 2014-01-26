using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Colors;

namespace DataExplorer.Domain.Maps.ColorMaps
{
    public class BooleanToColorMap : ColorMap
    {
        private readonly List<Color> _colors;

        public BooleanToColorMap(List<Color> colors)
        {
            _colors = colors;
        }

        public override Color Map(object value)
        {
            if (value == null)
                return NullColor;

            return (bool) value
                ? _colors.Last()
                : _colors.First();
        }

        public override object MapInverse(Color value)
        {
            if (value.Equals(_colors.First()))
                return false;
            
            return true;
        }
    }
}

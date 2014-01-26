using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Colors;

namespace DataExplorer.Domain.Maps.ColorMaps
{
    public class IntegerToColorMap : ColorMap
    {
        private readonly int _sourceMin;
        private readonly int _sourceMax;
        private readonly double _sourceWidth;
        private readonly List<Color> _colors;
        private readonly double _targetWidth;

        public IntegerToColorMap(int sourceMin, int sourceMax, List<Color> colors)
        {
            _sourceMin = sourceMin;
            _sourceMax = sourceMax;
            _sourceWidth = (double) sourceMax - (double) sourceMin;

            _colors = colors;
            _targetWidth = _colors.Count - 1;
        }

        public override Color Map(object value)
        {
            if (value == null)
                return NullColor;

            var width = (double)((int) value - _sourceMin);

            var ratio = width / _sourceWidth;

            var index = (int) (ratio * _targetWidth);

            return _colors[index];
        }

        public override object MapInverse(Color value)
        {
            var index = _colors.IndexOf(value);

            var ratio = index / _targetWidth;

            var result = _sourceMin + (_sourceWidth * ratio);

            if (result < int.MinValue)
                return int.MinValue;

            if (result > int.MaxValue)
                return int.MaxValue;

            return (int) result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Colors;

namespace DataExplorer.Domain.Maps.ColorMaps
{
    public class DateTimeToColorMap : ColorMap
    {
        private double _sourceMin;
        private double _sourceMax;
        private double _sourceWidth;
        private readonly List<Color> _colors;
        private double _targetWidth;

        public DateTimeToColorMap(DateTime sourceMin, DateTime sourceMax, List<Color> colors)
        {
            _sourceMin = sourceMin.Ticks;
            _sourceMax = sourceMax.Ticks;
            _sourceWidth = sourceMax.Ticks - sourceMin.Ticks;

            _colors = colors;
            _targetWidth = colors.Count();
        }

        public override Color Map(object value)
        {
            if (value == null)
                return NullColor;

            var width = ((DateTime) value).Ticks - _sourceMin;

            var ratio = width / _sourceWidth;

            var index = (int) (ratio * _targetWidth);

            // NOTE: This is a test to see if it fixes the out-of-bounds error
            index = Math.Min(index, _colors.Count - 1);

            return _colors[index];
        }

        public override object MapInverse(Color value)
        {
            var index = _colors.IndexOf(value);

            var ratio = index / (_targetWidth - 1);

            var result = _sourceMin + (_sourceWidth * ratio);

            if (result < DateTime.MinValue.Ticks)
                return DateTime.MinValue;

            if (result >= DateTime.MaxValue.Ticks)
                return DateTime.MaxValue;

            return new DateTime((long) result);
        }
    }
}

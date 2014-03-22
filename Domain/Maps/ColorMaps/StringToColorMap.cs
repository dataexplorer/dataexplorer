using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Colors;

namespace DataExplorer.Domain.Maps.ColorMaps
{
    public class StringToColorMap : ColorMap
    {
        private readonly List<string> _sourceValues;
        private readonly double _sourceWidth;
        private readonly List<Color> _colors;
        private readonly double _targetWidth;

        public StringToColorMap(List<string> sourceValues, List<Color> colors)
        {
            _sourceValues = sourceValues;
            _sourceWidth = sourceValues.Count() - 1;

            _colors = colors;
            _targetWidth = _colors.Count() - 1;
        }

        public override Color Map(object value)
        {
            if (value == null)
                return NullColor;

            var stringIndex = _sourceValues.IndexOf((string)value);

            var ratio = stringIndex / (_sourceWidth - 1d);

            var colorIndex = (int)(ratio * _targetWidth);

            return _colors[colorIndex];
        }

        public override object MapInverse(Color value)
        {
            var colorIndex = _colors.IndexOf(value);

            var ratio = colorIndex / _targetWidth;

            var index = (int) (_sourceWidth * ratio);

            if (index < 0)
                return _sourceValues.First();

            if (index > _sourceWidth - 1)
                return _sourceValues.Last();

            return _sourceValues[index];
        }
    }
}

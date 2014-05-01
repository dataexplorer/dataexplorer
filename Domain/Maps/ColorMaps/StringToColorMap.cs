using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Layouts;

namespace DataExplorer.Domain.Maps.ColorMaps
{
    public class StringToColorMap : ColorMap
    {
        private readonly List<string> _sourceValues;
        private readonly double _sourceWidth;
        private readonly List<Color> _colors;
        private readonly double _targetWidth;

        public StringToColorMap(
            List<string> sourceValues, 
            List<Color> colors, 
            SortOrder sortOrder)
            : base(sortOrder)
        {
            _sourceValues = sourceValues.Distinct().ToList();
            _sourceWidth = _sourceValues.Count();

            _colors = colors;
            _targetWidth = _colors.Count();
        }

        public override Color Map(object value)
        {
            if (value == null)
                return NullColor;

            var stringIndex = _sourceValues.IndexOf((string)value);

            var ratio = stringIndex / _sourceWidth;

            var colorIndex = (int) Math.Floor(ratio * _targetWidth);

            var orderedIndex = _sortOrder == SortOrder.Ascending
                ? colorIndex
                : _colors.Count - 1 - colorIndex;

            return _colors[orderedIndex];
        }

        public override object MapInverse(Color value)
        {
            var colorIndex = _colors.IndexOf(value);

            var orderedIndex = _sortOrder == SortOrder.Ascending
                ? colorIndex
                : _colors.Count - 1 - colorIndex;

            var ratio = orderedIndex / _targetWidth;

            var stringIndex = (int) Math.Ceiling(_sourceWidth * ratio);

            if (stringIndex < 0)
                return _sourceValues.First();

            if (stringIndex >= _sourceWidth)
                return _sourceValues.Last();

            return _sourceValues[stringIndex];
        }
    }
}

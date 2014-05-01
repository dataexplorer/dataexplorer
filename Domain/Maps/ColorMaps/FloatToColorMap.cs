using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Layouts;

namespace DataExplorer.Domain.Maps.ColorMaps
{
    public class FloatToColorMap : ColorMap
    {
        // NOTE: Must half all incoming values to avoid overflow
        // NOTE: since width from min to max is greater than 0 to max
        private const double ScaleFactor = 0.5d;
        private const double InverseScaleFactor = 2d;

        private readonly double _sourceMin;
        private readonly double _sourceMax;
        private readonly double _sourceWidth;
        private readonly List<Color> _colors;
        private readonly double _targetWidth;

        public FloatToColorMap(
            double sourceMin, 
            double sourceMax, 
            List<Color> colors, 
            SortOrder sortOrder) 
            : base(sortOrder)
        {
            _sourceMin = sourceMin;
            _sourceMax = sourceMax;
            _sourceWidth = sourceMax * ScaleFactor - sourceMin * ScaleFactor;

            _colors = colors;
            _targetWidth = colors.Count() - 1;
        }

        public override Color Map(object value)
        {
            if (value == null)
                return NullColor;

            var width = (double) value * ScaleFactor - _sourceMin * ScaleFactor;

            var ratio = width / _sourceWidth;

            var index =  (int) (ratio * _targetWidth);

            var orderedIndex = _sortOrder == SortOrder.Ascending
                ? index
                : _colors.Count - 1 - index;

            return _colors[orderedIndex];
        }

        public override object MapInverse(Color value)
        {
            var index = _colors.IndexOf(value);

            var orderedIndex = _sortOrder == SortOrder.Ascending
                ? index
                : _colors.Count - 1 - index;

            var ratio = orderedIndex / _targetWidth;

            var result = _sourceMin + ((_sourceWidth * ratio) * InverseScaleFactor);

            if (double.IsNegativeInfinity(result))
                return double.MinValue;

            if (double.IsPositiveInfinity(result))
                return double.MaxValue;

            return result;
        }
    }
}

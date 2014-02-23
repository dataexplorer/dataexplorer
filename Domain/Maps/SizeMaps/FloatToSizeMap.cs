using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Maps.SizeMaps
{
    public class FloatToSizeMap : SizeMap
    {
        // NOTE: Must half all incoming values to avoid overflow
        // NOTE: since width from min to max is greater than 0 to max
        private const double ScaleFactor = 0.5d;
        private const double InverseScaleFactor = 2d;

        private readonly double _sourceMin;
        private readonly double _sourceMax;
        private readonly double _sourceWidth;
        private readonly double _targetMin;
        private readonly double _targetMax;
        private readonly double _targetWidth;

        public FloatToSizeMap(double sourceMin, double sourceMax, double targetMin, double targetMax)
        {
            _sourceMin = sourceMin;
            _sourceMax = sourceMax;
            _sourceWidth = sourceMax * ScaleFactor - sourceMin * ScaleFactor;
            
            _targetMin = targetMin;
            _targetMax = targetMax;
            _targetWidth = targetMax - targetMin;
        }

        public override double? Map(object value)
        {
            if (value == null)
                return null;

            var width = (double) value * ScaleFactor - _sourceMin * ScaleFactor;

            var ratio = width / _sourceWidth;
            
            return _targetMin + (ratio * _targetWidth);
        }

        public override object MapInverse(double? value)
        {
            if (!value.HasValue)
                return null;

            var ratio = (double) value / _targetWidth;

            var result = _sourceMin + ((_sourceWidth * ratio) * InverseScaleFactor);

            if (double.IsNegativeInfinity(result))
                return double.MinValue;

            if (double.IsPositiveInfinity(result))
                return double.MaxValue;

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Maps.AxisMaps
{
    public class FloatToAxisMap : AxisMap
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
        private readonly bool _isReverse;

        public FloatToAxisMap(
            double sourceMin, 
            double sourceMax, 
            double targetMin, 
            double targetMax,
            bool isReverse)
        {
            _sourceMin = sourceMin;
            _sourceMax = sourceMax;
            _targetMin = targetMin;
            _targetMax = targetMax;
            _isReverse = isReverse;

            _sourceWidth = sourceMax * ScaleFactor - sourceMin * ScaleFactor;
            _targetWidth = targetMax - targetMin;
        }

        public override double? Map(object value)
        {
            if (value == null)
                return null;

            var width = (double) value * ScaleFactor - _sourceMin * ScaleFactor;

            var ratio = width / _sourceWidth;
            
            var targetValue = _targetMin + (ratio * _targetWidth);

            return _isReverse
                ? 1 - targetValue
                : targetValue;
        }

        public override object MapInverse(double? value)
        {
            if (!value.HasValue)
                return null;

            var targetValue = _isReverse
                ? 1 - value
                : value;

            var ratio = (double) targetValue / _targetWidth;

            var result = _sourceMin + ((_sourceWidth * ratio) * InverseScaleFactor);

            if (double.IsNegativeInfinity(result))
                return double.MinValue;

            if (double.IsPositiveInfinity(result))
                return double.MaxValue;

            return result;
        }
    }
}

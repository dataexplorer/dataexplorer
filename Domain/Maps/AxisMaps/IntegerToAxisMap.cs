using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Maps.AxisMaps
{
    public class IntegerToAxisMap : AxisMap
    {
        private readonly int _sourceMin;
        private readonly int _sourceMax;
        private readonly double _sourceWidth;
        private readonly double _targetMin;
        private readonly double _targetMax;
        private readonly double _targetWidth;
        private readonly bool _isReverse;

        public IntegerToAxisMap(
            int sourceMin, 
            int sourceMax, 
            double targetMin, 
            double targetMax,
            bool isReverse)
        {
            _sourceMin = sourceMin;
            _sourceMax = sourceMax;
            _targetMin = targetMin;
            _targetMax = targetMax;
            _isReverse = isReverse;

            _sourceWidth = (double) sourceMax - (double) sourceMin;
            _targetWidth = targetMax - targetMin;
        }

        public override double? Map(object value)
        {
            if (value == null)
                return null;

            var width = (double) (int) value - _sourceMin;

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

            var result = _sourceMin + (_sourceWidth * ratio);

            if (result < int.MinValue)
                return int.MinValue;

            if (result > int.MaxValue)
                return int.MaxValue;

            return (int) result;
        }
    }
}

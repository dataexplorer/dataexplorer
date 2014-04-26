using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Maps.AxisMaps
{
    public class BooleanToAxisMap : AxisMap
    {
        private readonly double _targetMin;
        private readonly double _targetMax;
        private readonly bool _isReverse;

        public BooleanToAxisMap(
            double targetMin, 
            double targetMax, 
            bool isReverse)
        {
            _targetMin = targetMin;
            _targetMax = targetMax;
            _isReverse = isReverse;
        }

        public override double? Map(object value)
        {
            if (value == null)
                return null;

            var targetValue = ((bool) value)
                ? _targetMax 
                : _targetMin;

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

            return targetValue != _targetMin;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Layouts;

namespace DataExplorer.Domain.Maps.SizeMaps
{
    public class BooleanToSizeMap : SizeMap
    {
        private readonly double _targetMin;
        private readonly double _targetMax;

        public BooleanToSizeMap(double targetMin, double targetMax, SortOrder sortOrder)
            : base(sortOrder)
        {
            _targetMin = targetMin;
            _targetMax = targetMax;
        }

        public override double? Map(object value)
        {
            if (value == null)
                return null;

            var targetValue = ((bool)value)
                ? _targetMax
                : _targetMin;

            return _sortOrder == SortOrder.Ascending
                ? targetValue
                : 1 - targetValue;
        }

        public override object MapInverse(double? value)
        {
            if (!value.HasValue)
                return null;
            
            var targetValue = _sortOrder == SortOrder.Ascending
                ? value
                : 1 - value;

            return targetValue != _targetMin;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Layouts;

namespace DataExplorer.Domain.Maps.AxisMaps
{
    public class StringToAxisMap : AxisMap
    {
        private readonly List<string> _sourceValues;
        private readonly int _sourceCount;
        private readonly double _targetMin;
        private readonly double _targetMax;
        private readonly double _targetWidth;

        public StringToAxisMap(
            List<string> sourceValues, 
            double targetMin, 
            double targetMax,
            SortOrder sortOrder)
            : base(sortOrder)
        {
            _sourceValues = sourceValues.Distinct().ToList();
            _sourceCount = _sourceValues.Count;
            _targetMin = targetMin;
            _targetMax = targetMax;

            _targetWidth = targetMax - targetMin;
        }

        public override double? Map(object value)
        {
            if (value == null)
                return null;

            var index = _sourceValues.IndexOf((string) value);

            var ratio = index / (_sourceCount - 1d);
            
            var targetValue = _targetMin + (ratio * _targetWidth);

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

            var ratio = (double) targetValue / _targetWidth;

            var index = (int)(_sourceCount * ratio);

            if (index < 0)
                return _sourceValues[0];

            if (index > _sourceCount - 1)
                return _sourceValues[_sourceCount - 1];

            return _sourceValues[index];
        }
    }
}

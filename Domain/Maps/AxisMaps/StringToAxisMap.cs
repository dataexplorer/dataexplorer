using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Maps.AxisMaps
{
    public class StringToAxisMap : IAxisMap
    {
        private readonly List<string> _sourceValues;
        private readonly int _sourceCount;
        private readonly double _targetMin;
        private readonly double _targetMax;
        private readonly double _targetWidth;

        public StringToAxisMap(List<string> sourceValues, double targetMin, double targetMax)
        {
            _sourceValues = sourceValues;
            _sourceCount = sourceValues.Count();
            _targetMin = targetMin;
            _targetMax = targetMax;
            _targetWidth = targetMax - targetMin;
        }

        public double? Map(object value)
        {
            if (value == null)
                return null;

            var index = _sourceValues.IndexOf((string) value);

            var ratio = index / (_sourceCount - 1d);
            
            return _targetMin + (ratio * _targetWidth);
        }

        public object MapInverse(double? value)
        {
            if (!value.HasValue)
                return null;

            var ratio = (double) value / _targetWidth;

            var index = (int)(_sourceCount * ratio);

            if (index < 0)
                return _sourceValues[0];

            if (index > _sourceCount - 1)
                return _sourceValues[_sourceCount - 1];

            return _sourceValues[index];
        }
    }
}

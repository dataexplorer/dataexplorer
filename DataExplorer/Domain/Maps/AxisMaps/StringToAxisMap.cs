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
        private readonly double _sourceCount;
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

        public double Map(object value)
        {
            var index = _sourceValues.IndexOf((string) value);
            var ratio = index / (_sourceCount - 1d);
            return _targetMin + (ratio * _targetWidth);
        }
    }
}

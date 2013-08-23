using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Maps.AxisMaps
{
    public class IntegerToAxisMap
    {
        private readonly int _sourceMin;
        private readonly int _sourceMax;
        private readonly double _targetMin;
        private readonly double _targetMax;
        private readonly double _sourceWidth;
        private readonly double _targetWidth;

        public IntegerToAxisMap(int sourceMin, int sourceMax, double targetMin, double targetMax)
        {
            _sourceMin = sourceMin;
            _sourceMax = sourceMax;
            _targetMin = targetMin;
            _targetMax = targetMax;

            _sourceWidth = sourceMax - sourceMin;
            _targetWidth = targetMax - targetMin;
        }

        public double Map(object value)
        {
            var width = (int) value - _sourceMin;
            var ratio = width / _sourceWidth;
            return _targetMin + (ratio * _targetWidth);
        }
    }
}

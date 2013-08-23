using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Maps.AxisMaps
{
    public class FloatToAxisMap : IAxisMap
    {
        private const double ScaleFactor = 0.5;

        private readonly double _sourceMin;
        private readonly double _sourceMax;
        private readonly double _targetMin;
        private readonly double _targetMax;
        private readonly double _sourceWidth;
        private readonly double _targetWidth;

        public FloatToAxisMap(double sourceMin, double sourceMax, double targetMin, double targetMax)
        {
            _sourceMin = sourceMin;
            _sourceMax = sourceMax;
            _targetMin = targetMin;
            _targetMax = targetMax;

            _sourceWidth = sourceMax * ScaleFactor - sourceMin * ScaleFactor;
            _targetWidth = targetMax - targetMin;
        }

        public double Map(object value)
        {
            var width = (double) value * ScaleFactor - _sourceMin * ScaleFactor;
            var ratio = width / _sourceWidth;
            return _targetMin + (ratio * _targetWidth);
        }
    }
}

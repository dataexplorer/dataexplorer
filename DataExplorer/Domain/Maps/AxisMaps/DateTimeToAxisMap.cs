using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Maps.AxisMaps
{
    public class DateTimeToAxisMap : IAxisMap
    {
        private readonly double _sourceMin;
        private readonly double _sourceMax;
        private readonly double _targetMin;
        private readonly double _targetMax;
        private readonly double _sourceWidth;
        private readonly double _targetWidth;

        public DateTimeToAxisMap(DateTime sourceMin, DateTime sourceMax, double targetMin, double targetMax)
        {
            _sourceMin = sourceMin.Ticks;
            _sourceMax = sourceMax.Ticks;
            _targetMin = targetMin;
            _targetMax = targetMax;

            _sourceWidth = sourceMax.Ticks - sourceMin.Ticks;
            _targetWidth = targetMax - targetMin;
        }

        public double Map(object value)
        {
            var width = ((DateTime) value).Ticks - _sourceMin;
            var ratio = width / _sourceWidth;
            return _targetMin + (ratio * _targetWidth);
        }
    }
}

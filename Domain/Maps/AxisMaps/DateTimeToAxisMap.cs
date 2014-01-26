using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Maps.AxisMaps
{
    public class DateTimeToAxisMap : AxisMap
    {
        private readonly double _sourceMin;
        private readonly double _sourceMax;
        private readonly double _targetMin;
        private readonly double _sourceWidth;
        private readonly double _targetMax;
        private readonly double _targetWidth;

        public DateTimeToAxisMap(DateTime sourceMin, DateTime sourceMax, double targetMin, double targetMax)
        {
            _sourceMin = sourceMin.Ticks;
            _sourceMax = sourceMax.Ticks;
            _sourceWidth = sourceMax.Ticks - sourceMin.Ticks;
            
            _targetMin = targetMin;
            _targetMax = targetMax;
            _targetWidth = targetMax - targetMin;
        }

        public override double? Map(object value)
        {
            if (value == null)
                return null;

            var width = ((DateTime) value).Ticks - _sourceMin;

            var ratio = width / _sourceWidth;
            
            return _targetMin + (ratio * _targetWidth);
        }

        public override object MapInverse(double? value)
        {
            if (!value.HasValue)
                return null;

            var ratio = value / _targetWidth;

            var result = _sourceMin + (_sourceWidth * ratio);

            if (result < DateTime.MinValue.Ticks)
                return DateTime.MinValue;

            if (result >= DateTime.MaxValue.Ticks)
                return DateTime.MaxValue;

            return new DateTime((long) result);
        }
    }
}

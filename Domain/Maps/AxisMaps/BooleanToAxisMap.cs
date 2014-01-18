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

        public BooleanToAxisMap(double targetMin, double targetMax)
        {
            _targetMin = targetMin;
            _targetMax = targetMax;
        }

        public override double? Map(object value)
        {
            if (value == null)
                return null;

            return (bool) value 
                ? _targetMax 
                : _targetMin;
        }

        public override object MapInverse(double? value)
        {
            if (!value.HasValue)
                return null;

            return value != _targetMin;

        }
    }
}

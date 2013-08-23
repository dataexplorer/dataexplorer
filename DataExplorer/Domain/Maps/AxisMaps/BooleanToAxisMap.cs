using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Maps.AxisMaps
{
    public class BooleanToAxisMap : IAxisMap
    {
        private readonly double _targetMin;
        private readonly double _targetMax;

        public BooleanToAxisMap(double targetMin, double targetMax)
        {
            _targetMin = targetMin;
            _targetMax = targetMax;
        }
        
        public double Map(object value)
        {
            return (bool) value 
                ? _targetMax 
                : _targetMin;
        }
    }
}

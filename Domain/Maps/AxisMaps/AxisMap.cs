using System;

namespace DataExplorer.Domain.Maps.AxisMaps
{
    public abstract class AxisMap
    {
        public abstract double? Map(object value);

        public abstract object MapInverse(double? value);
    }
}

using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Maps.AxisMaps;

namespace DataExplorer.Domain.Tests.Maps.AxisMaps
{
    public class FakeAxisMap : AxisMap
    {
        public FakeAxisMap() : base(SortOrder.Ascending)
        {
            
        }

        public FakeAxisMap(SortOrder sortOrder) 
            : base(sortOrder)
        {
        }

        public override double? Map(object value)
        {
            return (double?) value;
        }

        public override object MapInverse(double? value)
        {
            return value;
        }
    }
}
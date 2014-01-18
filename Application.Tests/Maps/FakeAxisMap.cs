using DataExplorer.Domain.Maps;

namespace DataExplorer.Application.Tests.Maps
{
    public class FakeAxisMap : AxisMap
    {
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
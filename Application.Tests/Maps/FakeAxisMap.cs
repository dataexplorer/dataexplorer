using DataExplorer.Domain.Maps;

namespace DataExplorer.Application.Tests.Maps
{
    public class FakeAxisMap : IAxisMap
    {
        public double? Map(object value)
        {
            return (double?) value;
        }

        public object MapInverse(double? value)
        {
            return value;
        }
    }
}
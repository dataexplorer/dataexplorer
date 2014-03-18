using System;
using DataExplorer.Domain.Maps.SizeMaps;

namespace DataExplorer.Domain.Tests.Maps.SizeMaps
{
    public class FakeSizeMap : SizeMap
    {
        public override double? Map(object value)
        {
            throw new NotImplementedException();
        }

        public override object MapInverse(double? value)
        {
            throw new NotImplementedException();
        }
    }
}
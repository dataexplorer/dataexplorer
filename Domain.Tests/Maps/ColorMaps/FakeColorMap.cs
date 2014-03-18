using System;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Maps.ColorMaps;

namespace DataExplorer.Domain.Tests.Maps.ColorMaps
{
    public class FakeColorMap : ColorMap
    {
        public override Color Map(object value)
        {
            throw new NotImplementedException();
        }

        public override object MapInverse(Color value)
        {
            throw new NotImplementedException();
        }
    }
}
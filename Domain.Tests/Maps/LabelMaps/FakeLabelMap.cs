using System;
using DataExplorer.Domain.Maps.LabelMaps;

namespace DataExplorer.Domain.Tests.Maps.LabelMaps
{
    public class FakeLabelMap : LabelMap
    {
        public override string Map(object value)
        {
            throw new NotImplementedException();
        }
    }
}
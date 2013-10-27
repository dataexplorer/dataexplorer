using System;
using DataExplorer.Domain.Maps;

namespace DataExplorer.Tests.Application.Maps
{
    public class FakeAxisMap : IAxisMap
    {
        public double? Map(object value)
        {
            return (double?) value;
        }
    }
}
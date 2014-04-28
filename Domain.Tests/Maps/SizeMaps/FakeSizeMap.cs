using System;
using System.Windows;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Maps.SizeMaps;

namespace DataExplorer.Domain.Tests.Maps.SizeMaps
{
    public class FakeSizeMap : SizeMap
    {
        private readonly double _size;
        private readonly object _value;

        public FakeSizeMap() : base(SortOrder.Ascending)
        {
            
        }

        public FakeSizeMap(SortOrder sortOrder) 
            : base(sortOrder)
        {
            
        }

        public FakeSizeMap(SortOrder sortOrder, double size, object value)
            : base(sortOrder)
        {
            _size = size;
            _value = value;
        }

        public override double? Map(object value)
        {
            return _size;
        }

        public override object MapInverse(double? value)
        {
            return _value;
        }
    }
}
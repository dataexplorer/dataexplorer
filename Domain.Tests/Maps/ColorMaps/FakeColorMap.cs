using System;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Maps.ColorMaps;

namespace DataExplorer.Domain.Tests.Maps.ColorMaps
{
    public class FakeColorMap : ColorMap
    {
        private readonly Color _color;
        private readonly object _value;

        public FakeColorMap(SortOrder sortOrder, Color color, object value)
            : base(sortOrder)
        {
            _color = color;
            _value = value;
        }

        public FakeColorMap() : base(SortOrder.Ascending)
        {
            
        }

        public FakeColorMap(SortOrder sortOrder) 
            : base(sortOrder)
        {
        }

        public override Color Map(object value)
        {
            return _color;
        }

        public override object MapInverse(Color value)
        {
            return _value;
        }
    }
}
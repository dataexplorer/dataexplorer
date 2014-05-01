using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Layouts;

namespace DataExplorer.Domain.Maps.ColorMaps
{
    public abstract class ColorMap
    {
        protected static Color NullColor = new Color(127, 127, 127);
        
        protected readonly SortOrder _sortOrder;

        protected ColorMap()
        {
            _sortOrder = SortOrder.Descending;
        }

        protected ColorMap(SortOrder sortOrder)
        {
            _sortOrder = sortOrder;
        }

        public SortOrder SortOrder
        {
            get { return _sortOrder; }
        }
        
        public abstract Color Map(object value);

        public abstract object MapInverse(Color value);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Layouts;

namespace DataExplorer.Domain.Maps.SizeMaps
{
    public abstract class SizeMap
    {
        protected readonly SortOrder _sortOrder;

        protected SizeMap()
        {
            
        }

        protected SizeMap(SortOrder sortOrder)
        {
            _sortOrder = sortOrder;
        }

        public SortOrder SortOrder
        {
            get { return _sortOrder; }
        }

        public abstract double? Map(object value);

        public abstract object MapInverse(double? value);
    }
}

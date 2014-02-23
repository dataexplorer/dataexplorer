using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Persistence.Projects;

namespace DataExplorer.Persistence.Filters.Serializers.NullFilters
{
    public class NullFilterSerializer 
        : BaseSerializer,
        INullFilterSerializer
    {
        private const string FilterTag = "null-filter";
        private const string ColumnIdTag = "column-id";

        public NullFilterSerializer(IPropertySerializer propertySerializer) 
            : base(propertySerializer)
        {
            
        }

        public XElement Serialize(NullFilter filter)
        {
            var xFilter = new XElement(FilterTag);

            AddColumn(xFilter, ColumnIdTag, filter.Column);

            return xFilter;
        }
        
        public NullFilter Deserialize(XElement xFilter, List<Column> columns)
        {
            var column = GetColumn(xFilter, ColumnIdTag, columns);

            var filter = new NullFilter(column);

            return filter;
        }

        
    }
}

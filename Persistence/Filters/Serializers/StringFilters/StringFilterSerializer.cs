using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Persistence.Projects;

namespace DataExplorer.Persistence.Filters.Serializers.StringFilters
{
    public class StringFilterSerializer 
        : BaseSerializer,
        IStringFilterSerializer
    {
        private const string FilterTag = "integer-filter";
        private const string ColumnIdTag = "column-id";
        private const string ValueTag = "value";
        private const string IncludeNullTag = "include-null";
        
        public StringFilterSerializer(IPropertySerializer propertySerializer) 
            : base(propertySerializer)
        {
            
        }

        public XElement Serialize(StringFilter filter)
        {
            var xFilter = new XElement(FilterTag);

            AddColumn(xFilter, ColumnIdTag, filter.Column);

            AddProperty(xFilter, ValueTag, filter.Value);

            AddProperty(xFilter, IncludeNullTag, filter.IncludeNull);
            
            return xFilter;
        }
        
        public StringFilter Deserialize(XElement xFilter, List<Column> columns)
        {
            var column = GetColumn(xFilter, ColumnIdTag, columns);

            var value = GetProperty<string>(xFilter, ValueTag);

            var includeNull = GetProperty<bool>(xFilter, IncludeNullTag);

            return new StringFilter(column, value, includeNull);
        }
    }
}

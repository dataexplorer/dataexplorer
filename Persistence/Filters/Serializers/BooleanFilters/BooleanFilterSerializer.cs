using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Persistence.Common.Serializers;
using DataExplorer.Persistence.Projects;

namespace DataExplorer.Persistence.Filters.Serializers.BooleanFilters
{
    public class BooleanFilterSerializer 
        : BaseSerializer,
        IBooleanFilterSerializer
    {
        private const string FilterTag = "boolean-filter";
        private const string ColumnIdTag = "column-id";
        private const string IncludeTrueTag = "include-true";
        private const string IncludeFalseTag = "include-false";
        private const string IncludeNullTag = "include-null";
        
        public BooleanFilterSerializer(IPropertySerializer propertySerializer)
            : base(propertySerializer)
        {
        
        }

        public XElement Serialize(BooleanFilter filter)
        {
            var xFilter = new XElement(FilterTag);

            AddColumn(xFilter, ColumnIdTag, filter.Column);

            AddProperty(xFilter, IncludeTrueTag, filter.IncludeTrue);

            AddProperty(xFilter, IncludeFalseTag, filter.IncludeFalse);

            AddProperty(xFilter, IncludeNullTag, filter.IncludeNull);
            
            return xFilter;
        }

        public BooleanFilter Deserialize(XElement xFilter, List<Column> columns)
        {
            var column = GetColumn(xFilter, ColumnIdTag, columns);

            var includeTrue = GetProperty<bool>(xFilter, IncludeTrueTag);

            var includeFalse = GetProperty<bool>(xFilter, IncludeFalseTag);

            var includeNull = GetProperty<bool>(xFilter, IncludeNullTag);
            
            return new BooleanFilter(column, includeTrue, includeFalse, includeNull);
        }
    }
}

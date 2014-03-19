using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Persistence.Common.Serializers;
using DataExplorer.Persistence.Projects;

namespace DataExplorer.Persistence.Filters.Serializers.IntegerFilters
{
    public class IntegerFilterSerializer 
        : BaseSerializer,
        IIntegerFilterSerializer
    {
        private const string FilterTag = "integer-filter";
        private const string ColumnIdTag = "column-id";
        private const string LowerValueTag = "lower-value";
        private const string UpperValueTag = "upper-value";
        private const string IncludeNullTag = "include-null";

        public IntegerFilterSerializer(IPropertySerializer propertySerializer)
            :base(propertySerializer)
        {
            
        }

        public XElement Serialize(IntegerFilter filter)
        {
            var xFilter = new XElement(FilterTag);

            AddColumn(xFilter, ColumnIdTag, filter.Column);

            AddProperty(xFilter, LowerValueTag, filter.LowerValue);

            AddProperty(xFilter, UpperValueTag, filter.UpperValue);

            AddProperty(xFilter, IncludeNullTag, filter.IncludeNull);

            return xFilter;
        }
        
        public IntegerFilter Deserialize(XElement xFilter, List<Column> columns)
        {
            var column = GetColumn(xFilter, ColumnIdTag, columns);

            var lowerValue = GetProperty<int>(xFilter, LowerValueTag);

            var upperValue = GetProperty<int>(xFilter, UpperValueTag);

            var includeNull = GetProperty<bool>(xFilter, IncludeNullTag);

            return new IntegerFilter(column, lowerValue, upperValue, includeNull);
        }
    }
}

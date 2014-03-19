using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Persistence.Common.Serializers;
using DataExplorer.Persistence.Projects;

namespace DataExplorer.Persistence.Filters.Serializers.FloatFilters
{
    public class FloatFilterSerializer 
        : BaseSerializer,
        IFloatFilterSerializer
    {
        private const string FilterTag = "float-filter";
        private const string ColumnIdTag = "column-id";
        private const string LowerValueTag = "lower-value";
        private const string UpperValueTag = "upper-value";
        private const string IncludeNullTag = "include-null";

        public FloatFilterSerializer(IPropertySerializer propertySerializer)
            : base(propertySerializer)
        {
        }

        public XElement Serialize(FloatFilter filter)
        {
            var xFilter = new XElement(FilterTag);

            AddColumn(xFilter, ColumnIdTag, filter.Column);

            AddProperty(xFilter, LowerValueTag, filter.LowerValue);

            AddProperty(xFilter, UpperValueTag, filter.UpperValue);

            AddProperty(xFilter, IncludeNullTag, filter.IncludeNull);

            return xFilter;
        }

        public FloatFilter Deserialize(XElement xFilter, List<Column> columns)
        {
            var column = GetColumn(xFilter, ColumnIdTag, columns);

            var lowerValue = GetProperty<Double>(xFilter, LowerValueTag);

            var upperValue = GetProperty<Double>(xFilter, UpperValueTag);

            var includeNull = GetProperty<bool>(xFilter, IncludeNullTag);

            return new FloatFilter(column, lowerValue, upperValue, includeNull);
        }
    }
}

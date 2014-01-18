using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Infrastructure.Serializers.Filters.BooleanFilters;
using DataExplorer.Infrastructure.Serializers.Filters.DateTimeFilters;
using DataExplorer.Infrastructure.Serializers.Filters.FloatFilters;
using DataExplorer.Infrastructure.Serializers.Filters.IntegerFilters;
using DataExplorer.Infrastructure.Serializers.Filters.NullFilters;
using DataExplorer.Infrastructure.Serializers.Filters.StringFilters;

namespace DataExplorer.Infrastructure.Serializers.Filters
{
    public class FilterSerializer : IFilterSerializer
    {
        private const string FilterCannotBeSerializedMessage = "Filter cannot be serialized because filter type is not recognized.";
        private const string FilterCannotBeDeserializedMessage = "Filter cannot be deserialized because filter type is not recognized.";

        private const string NullFilterTag = "null-filter";
        private const string BooleanFilterTag = "boolean-filter";
        private const string DateTimeFilterTag = "datetime-filter";
        private const string FloatFilterTag = "float-filter";
        private const string IntegerFilterTag = "integer-filter";
        private const string StringFilterTag = "string-filter";

        private readonly INullFilterSerializer _nullFilterSerializer;
        private readonly IBooleanFilterSerializer _booleanFilterSerializer;
        private readonly IDateTimeFilterSerializer _dateTimeFilterSerializer;
        private readonly IFloatFilterSerializer _floatFilterSerializer;
        private readonly IIntegerFilterSerializer _integerFilterSerializer;
        private readonly IStringFilterSerializer _stringFilterSerializer;

        public FilterSerializer(
            INullFilterSerializer nullFilterSerializer, 
            IBooleanFilterSerializer booleanFilterSerializer, 
            IDateTimeFilterSerializer dateTimeFilterSerializer, 
            IFloatFilterSerializer floatFilterSerializer, 
            IIntegerFilterSerializer integerFilterSerializer, 
            IStringFilterSerializer stringFilterSerializer)
        {
            _nullFilterSerializer = nullFilterSerializer;
            _booleanFilterSerializer = booleanFilterSerializer;
            _dateTimeFilterSerializer = dateTimeFilterSerializer;
            _floatFilterSerializer = floatFilterSerializer;
            _integerFilterSerializer = integerFilterSerializer;
            _stringFilterSerializer = stringFilterSerializer;
        }

        public XElement Serialize(Filter filter)
        {
            if (filter is NullFilter)
                return _nullFilterSerializer.Serialize((NullFilter) filter);

            if (filter is BooleanFilter)
                return _booleanFilterSerializer.Serialize((BooleanFilter) filter);

            if (filter is DateTimeFilter)
                return _dateTimeFilterSerializer.Serialize((DateTimeFilter) filter);

            if (filter is FloatFilter)
                return _floatFilterSerializer.Serialize((FloatFilter) filter);

            if (filter is IntegerFilter)
                return _integerFilterSerializer.Serialize((IntegerFilter) filter);

            if (filter is StringFilter)
                return _stringFilterSerializer.Serialize((StringFilter) filter);

            throw new ArgumentException(FilterCannotBeSerializedMessage);
        }

        public Filter Deserialize(XElement xFilter, IEnumerable<Column> columns)
        {
            if (xFilter.Name.LocalName == NullFilterTag)
                return _nullFilterSerializer.Deserialize(xFilter, columns);

            if (xFilter.Name.LocalName == BooleanFilterTag)
                return _booleanFilterSerializer.Deserialize(xFilter, columns);

            if (xFilter.Name.LocalName == DateTimeFilterTag)
                return _dateTimeFilterSerializer.Deserialize(xFilter, columns);

            if (xFilter.Name.LocalName == FloatFilterTag)
                return _floatFilterSerializer.Deserialize(xFilter, columns);

            if (xFilter.Name.LocalName == IntegerFilterTag)
                return _integerFilterSerializer.Deserialize(xFilter, columns);

            if (xFilter.Name.LocalName == StringFilterTag)
                return _stringFilterSerializer.Deserialize(xFilter, columns);

            throw new ArgumentException(FilterCannotBeDeserializedMessage);
        }
    }
}

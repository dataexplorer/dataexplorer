using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Persistence.Filters.Serializers.BooleanFilters;
using DataExplorer.Persistence.Filters.Serializers.DateTimeFilters;
using DataExplorer.Persistence.Filters.Serializers.FloatFilters;
using DataExplorer.Persistence.Filters.Serializers.ImageFilters;
using DataExplorer.Persistence.Filters.Serializers.IntegerFilters;
using DataExplorer.Persistence.Filters.Serializers.NullFilters;
using DataExplorer.Persistence.Filters.Serializers.StringFilters;

namespace DataExplorer.Persistence.Filters.Serializers
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
        private const string ImageFilterTag = "image-filter";

        private readonly INullFilterSerializer _nullFilterSerializer;
        private readonly IBooleanFilterSerializer _booleanFilterSerializer;
        private readonly IDateTimeFilterSerializer _dateTimeFilterSerializer;
        private readonly IFloatFilterSerializer _floatFilterSerializer;
        private readonly IIntegerFilterSerializer _integerFilterSerializer;
        private readonly IStringFilterSerializer _stringFilterSerializer;
        private readonly IImageFilterSerializer _imageFilterSerializer;

        public FilterSerializer(
            INullFilterSerializer nullFilterSerializer, 
            IBooleanFilterSerializer booleanFilterSerializer, 
            IDateTimeFilterSerializer dateTimeFilterSerializer, 
            IFloatFilterSerializer floatFilterSerializer, 
            IIntegerFilterSerializer integerFilterSerializer, 
            IStringFilterSerializer stringFilterSerializer,
            IImageFilterSerializer imageFilterSerializer)
        {
            _nullFilterSerializer = nullFilterSerializer;
            _booleanFilterSerializer = booleanFilterSerializer;
            _dateTimeFilterSerializer = dateTimeFilterSerializer;
            _floatFilterSerializer = floatFilterSerializer;
            _integerFilterSerializer = integerFilterSerializer;
            _stringFilterSerializer = stringFilterSerializer;
            _imageFilterSerializer = imageFilterSerializer;
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

            if (filter is ImageFilter)
                return _imageFilterSerializer.Serialize((ImageFilter) filter);

            throw new ArgumentException(FilterCannotBeSerializedMessage);
        }

        public Filter Deserialize(XElement xFilter, List<Column> columns)
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

            if (xFilter.Name.LocalName == ImageFilterTag)
                return _imageFilterSerializer.Deserialize(xFilter, columns);

            throw new ArgumentException(FilterCannotBeDeserializedMessage);
        }
    }
}

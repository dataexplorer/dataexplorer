using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Persistence.Filters.Serializers
{
    public class FilterSetSerializer : IFilterSetSerializer
    {
        private static readonly string FiltersTag = "filters";

        private readonly IFilterSerializer _filterSerializer;

        public FilterSetSerializer(IFilterSerializer filterSerializer)
        {
            _filterSerializer = filterSerializer;
        }

        public XElement Serialize(IEnumerable<Filter> filters)
        {
            var xFilters = new XElement(FiltersTag);

            foreach (var filter in filters)
            {
                var xSource = _filterSerializer.Serialize(filter);

                xFilters.Add(xSource);
            }

            return xFilters;
        }

        public IEnumerable<Filter> Deserialize(XElement xFilters, IEnumerable<Column> columns)
        {
            var filters = new List<Filter>();

            foreach (var xFilter in xFilters.Elements())
            {
                var filter = _filterSerializer.Deserialize(xFilter, columns);

                filters.Add(filter);
            }

            return filters;
        }
    }
}

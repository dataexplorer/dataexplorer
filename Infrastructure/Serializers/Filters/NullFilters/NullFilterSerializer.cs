using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Infrastructure.Serializers.Properties;

namespace DataExplorer.Infrastructure.Serializers.Filters.NullFilters
{
    public class NullFilterSerializer : INullFilterSerializer
    {
        private const string ColumnIdTag = "column-id";

        private readonly IPropertySerializer _propertySerializer;

        public NullFilterSerializer(IPropertySerializer propertySerializer)
        {
            _propertySerializer = propertySerializer;
        }

        public XElement Serialize(NullFilter filter)
        {
            var xFilter = new XElement("null-filter");

            SerializeColumnId(filter, xFilter);

            return xFilter;
        }

        private void SerializeColumnId(NullFilter filter, XElement xFilter)
        {
            var xColumnId = _propertySerializer.Serialize(ColumnIdTag, filter.Column.Id);

            xFilter.Add(xColumnId);
        }

        public NullFilter Deserialize(XElement xFilter, IEnumerable<Column> columns)
        {
            var columnId = DeserializeColumnId(xFilter);

            var column = columns.Single(p => p.Id == columnId);

            var filter = new NullFilter(column);

            return filter;
        }

        private int DeserializeColumnId(XElement xFilter)
        {
            var xColumnId = xFilter.Elements()
                .First(p => p.Name.LocalName == ColumnIdTag);

            var columnId = _propertySerializer.Deserialize<int>(xColumnId);

            return columnId;

        }
    }
}

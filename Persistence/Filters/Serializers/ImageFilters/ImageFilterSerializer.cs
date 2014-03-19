using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Persistence.Common.Serializers;

namespace DataExplorer.Persistence.Filters.Serializers.ImageFilters
{
    public class ImageFilterSerializer 
        : BaseSerializer,
        IImageFilterSerializer
    {
        private const string FilterTag = "image-filter";
        private const string ColumnIdTag = "column-id";
        private const string IncludeNullTag = "include-null";
        private const string IncludeNotNullTag = "include-not-null";

        public ImageFilterSerializer(PropertySerializer propertySerializer) 
            : base(propertySerializer)
        {
        }

        public XElement Serialize(ImageFilter filter)
        {
            var xFilter = new XElement(FilterTag);

            AddColumn(xFilter, ColumnIdTag, filter.Column);

            AddProperty(xFilter, IncludeNullTag, filter.IncludeNull);

            AddProperty(xFilter, IncludeNotNullTag, filter.IncludeNotNull);

            return xFilter;
        }

        public ImageFilter Deserialize(XElement xFilter, List<Column> columns)
        {
            var column = GetColumn(xFilter, ColumnIdTag, columns);

            var includeNull = GetProperty<bool>(xFilter, IncludeNullTag);

            var includeNotNull = GetProperty<bool>(xFilter, IncludeNotNullTag);

            return new ImageFilter(column, includeNull, includeNotNull);
        }
    }
}

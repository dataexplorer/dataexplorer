using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Persistence.Projects;

namespace DataExplorer.Persistence
{
    public abstract class BaseSerializer
    {
        protected readonly IPropertySerializer _propertySerializer;

        public BaseSerializer(IPropertySerializer propertySerializer)
        {
            _propertySerializer = propertySerializer;
        }

        protected void AddProperty<T>(XElement xParent, string name, T value)
        {
            var xProperty = _propertySerializer.Serialize(name, value);

            xParent.Add(xProperty);
        }

        protected T GetProperty<T>(XElement xParent, string name)
        {
            var xProperty = xParent.Elements()
                .FirstOrDefault(p => p.Name == name);

            if (xProperty == null)
                return default(T);

            var value = _propertySerializer.Deserialize<T>(xProperty);

            return value;
        }

        protected void AddColumn(XElement xParent, string name, Column column)
        {
            var columnId = (column == null)
                ? (int?) null
                : column.Id;

            AddProperty(xParent, name, columnId);
        }

        protected Column GetColumn(XElement xParent, string name, List<Column> columns)
        {
            var columnId = GetProperty<int?>(xParent, name);

            var column = columnId != null
                ? columns.First(p => p.Id == columnId)
                : null;

            return column;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace DataExplorer.Persistence.Columns.Serializers
{
    public class ColumnDataTypeSerializer : IColumnDataTypeSerializer
    {
        public List<Type> Deserialize(XElement xColumnSet)
        {
            var xColumns = xColumnSet.Elements("column");

            var xTypes = xColumns.Select(p => p.Element("type"));

            var types = xTypes.Select(p => Type.GetType(p.Value));

            var nullableTypes = types.Select(GetNullableType);

            return nullableTypes.ToList();
        }

        private Type GetNullableType(Type type)
        {
            if (type == typeof(Boolean))
                return typeof(Boolean?);

            if (type == typeof(DateTime))
                return typeof(DateTime?);

            if (type == typeof(Double))
                return typeof(Double?);

            if (type == typeof(Int32))
                return typeof(Int32?);

            if (type == typeof(String))
                return typeof(String);

            throw new ArgumentException("Type cannot be deserialized because it has no nullable equivalent.");
        }
    }
}

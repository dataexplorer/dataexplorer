using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Persistence.Common.Serializers;

namespace DataExplorer.Persistence.Columns.Serializers
{
    public class ColumnDataTypeSerializer : IColumnDataTypeSerializer
    {
        private readonly IDataTypeSerializer _dataTypeSerializer;

        public ColumnDataTypeSerializer(IDataTypeSerializer dataTypeSerializer)
        {
            _dataTypeSerializer = dataTypeSerializer;
        }

        public List<Type> Deserialize(XElement xColumnSet)
        {
            var xColumns = xColumnSet.Elements("column");

            var xTypes = xColumns.Select(p => p.Element("data-type"));

            var types = xTypes.Select(p => _dataTypeSerializer.Deserialize(p));

            var nullableTypes = types.Select(p => GetNullableType(p));

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

            return type;
        }
    }
}

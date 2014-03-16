using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Infrastructure.Tests.Importers
{
    public class DataColumnBuilder
    {
        private string _name = string.Empty;
        private Type _dataType = null;

        public DataColumnBuilder WithColumnName(string columnName)
        {
            _name = columnName;
            return this;
        }

        public DataColumnBuilder WithDataType(Type dataType)
        {
            _dataType = dataType;
            return this;
        }

        public DataColumn Build()
        {
            return new DataColumn(_name, _dataType);
        }
    }
}

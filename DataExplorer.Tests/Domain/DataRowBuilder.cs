using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Tests.Domain
{
    public class DataRowBuilder
    {
        private readonly DataTable _dataTable;
        private readonly List<object> _fields; 

        public DataRowBuilder()
        {
            _dataTable = new DataTable();
            _fields = new List<object>();
        }

        public DataRowBuilder WithValues(params object[] values)
        {
            for (int i = 0; i < values.Length; i++)
                _dataTable.Columns.Add(new DataColumn());
            _fields.AddRange(values);
            return this;
        }

        public DataRow Build()
        {
            var dataRow = _dataTable.NewRow();
            for (int i = 0; i < _dataTable.Columns.Count; i++)
                dataRow[i] = _fields[i];
            return dataRow;
        }

        public List<DataRow> BuildList()
        {
            var dataRow = Build();
            return new List<DataRow>() { dataRow };
        }
    }
}

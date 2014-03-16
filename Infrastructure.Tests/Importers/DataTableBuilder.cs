using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Infrastructure.Tests.Importers
{
    public class DataTableBuilder
    {
        private readonly DataTable _dataTable;

        public DataTableBuilder()
        {
            _dataTable = new DataTable();
        }

        public DataTableBuilder WithColumn(DataColumn dataColumn)
        {
            _dataTable.Columns.Add(dataColumn);
            return this;
        }

        public DataTableBuilder WithRow(params object[] values)
        {
            _dataTable.Rows.Add(values);
            return this;
        }

        public DataTable Build()
        {
            return _dataTable;
        }
    }
}

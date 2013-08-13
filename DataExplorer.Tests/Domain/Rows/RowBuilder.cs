using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Tests.Domain.Rows
{
    public class RowBuilder
    {
        private readonly List<object> _fields; 

        public RowBuilder()
        {
            _fields = new List<object>();
        }

        public RowBuilder WithValues(params object[] values)
        {
            _fields.AddRange(values);
            return this;
        }

        public Row Build()
        {
            var row = new Row(_fields);
            return row;
        }

        public List<Row> BuildList()
        {
            var row = Build();
            return new List<Row>() { row };
        }
    }
}

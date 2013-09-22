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

        public RowBuilder WithField(object field)
        {
            _fields.Add(field);
            return this;
        }

        public RowBuilder WithFields(params object[] values)
        {
            _fields.AddRange(values);
            return this;
        }

        public Row Build()
        {
            var row = new Row(_fields);
            return row;
        }
    }
}

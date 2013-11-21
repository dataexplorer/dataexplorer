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
        private int _id;
        private readonly List<object> _fields; 

        public RowBuilder()
        {
            _id = 0;
            _fields = new List<object>();
        }

        public RowBuilder WithId(int id)
        {
            _id = id;
            return this;
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
            var row = new Row(_id, _fields);
            return row;
        }
    }
}

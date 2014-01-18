using System;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Predicates;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Filters
{
    public class StringFilter : Filter
    {
        protected readonly string _value;
        
        public StringFilter(Column column, string value, bool includeNull)
            : base(column, includeNull)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }

        public override Func<Row, bool> CreatePredicate()
        {
            return new StringPredicate()
                .Create(_column, _value);
        }
    }
}

using System;
using System.Collections.Generic;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Predicates;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Filters.BooleanFilters
{
    public class BooleanFilter : Filter
    {
        private readonly List<bool?> _values;

        public BooleanFilter(Column column, List<bool?> values)
            : base(column)
        {
            _values = values;
        }

        public BooleanFilter(Column column, bool? value)
            : base(column)
        {
            _values = new List<bool?> { value };
        }

        public List<bool?> Values
        {
            get { return _values; }
        }

        public override Func<Row, bool> CreatePredicate()
        {
            return new BooleanPredicate().Create(_column, _values);
        }
    }
}

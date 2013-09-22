﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Predicates;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Filters
{
    public class NullableStringFilter : StringFilter
    {
        private readonly bool _includeNulls;

        public NullableStringFilter(Column column, string value, bool includeNulls) 
            : base(column, value)
        {
            _includeNulls = includeNulls;
        }

        public bool IncludeNulls
        {
            get { return _includeNulls; }
        }

        public override Func<Row, bool> CreatePredicate()
        {
            return new NullableStringPredicate()
                .Create(_column, _value, _includeNulls);
        }
    }
}

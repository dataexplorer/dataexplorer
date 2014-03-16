using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Predicates;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Filters
{
    public class ImageFilter : Filter
    {
        private bool _includeNotNull;

        public ImageFilter(Column column, bool includeNull, bool includeNotNull) 
            : base(column, includeNull)
        {
            _includeNotNull = includeNotNull;
        }

        public bool IncludeNotNull
        {
            get { return _includeNotNull; }
            set { _includeNotNull = value; }
        }

        public override Func<Row, bool> CreatePredicate()
        {
            return new ImagePredicate()
                .Create(_column, _includeNull, _includeNotNull);
        }
    }
}

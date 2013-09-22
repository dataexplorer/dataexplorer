using System;
using System.Collections.Generic;
using System.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Domain.FilterTrees
{
    public abstract class FilterTreeNode
    {
        protected readonly string _name;
        protected readonly Column _column;

        public FilterTreeNode(string name, Column column)
        {
            _name = name;
            _column = column;
        }

        public string Name
        {
            get { return _name; }
        }

        public Column Column
        {
            get { return _column; }
        }

        public abstract IEnumerable<FilterTreeNode> CreateChildren();

        public abstract Filter CreateFilter();

        protected bool HasValuesInRange(object low, object high)
        {
            return _column.Values
                .Where(p => p != null)
                .Cast<IComparable>()
                .Any(p => p.CompareTo(low) >= 0
                    && p.CompareTo(high) <= 0);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Filters.NullFilters;

namespace DataExplorer.Domain.FilterTrees.NullFilterTrees
{
    public class NullFilterTreeLeaf : FilterTreeNode
    {
        public NullFilterTreeLeaf(string name, Column column) 
            : base(name, column)
        {
        }

        public override IEnumerable<FilterTreeNode> CreateChildren()
        {
            return new List<FilterTreeNode>();
        }

        public override Filter CreateFilter()
        {
            return new NullFilter(_column);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Domain.FilterTrees.BooleanFilterTrees
{
    public class BooleanFilterTreeLeaf : BooleanFilterTreeNode
    {
        private readonly bool _value;

        public BooleanFilterTreeLeaf(string name, Column column, bool value)
            : base(name, column)
        {
            _value = value;
        }

        public bool Value
        {
            get { return _value; }
        }

        public override IEnumerable<FilterTreeNode> CreateChildren()
        {
            return new List<FilterTreeNode>();
        }

        public override Filter CreateFilter()
        {
            return new BooleanFilter(_column, _value);
        }
    }
}

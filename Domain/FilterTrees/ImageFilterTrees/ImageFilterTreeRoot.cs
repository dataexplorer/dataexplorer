using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.FilterTrees.NullFilterTrees;

namespace DataExplorer.Domain.FilterTrees.ImageFilterTrees
{
    public class ImageFilterTreeRoot : FilterTreeNode
    {
        public ImageFilterTreeRoot(string name, Column column) : base(name, column)
        {
        }

        public override IEnumerable<FilterTreeNode> CreateChildren()
        {
            var children = new List<FilterTreeNode>();

            var nullNode = new NullFilterTreeLeaf("Null", _column);
            children.Add(nullNode);

            return children;
        }

        public override Filter CreateFilter()
        {
            return new ImageFilter(_column, _column.HasNulls, true);
        }
    }
}

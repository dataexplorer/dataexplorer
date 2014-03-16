using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Domain.FilterTrees.ImageFilterTrees
{
    public class ImageFilterTreeRoot : FilterTreeNode
    {
        public ImageFilterTreeRoot(string name, Column column) : base(name, column)
        {
        }

        public override IEnumerable<FilterTreeNode> CreateChildren()
        {
            return new List<FilterTreeNode>();
        }

        public override Filter CreateFilter()
        {
            throw new NotImplementedException();
        }
    }
}

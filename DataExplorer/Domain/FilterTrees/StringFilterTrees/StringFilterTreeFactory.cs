using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees.StringFilterTrees
{
    public class StringFilterTreeFactory : IStringFilterTreeFactory
    {
        public FilterTreeNode CreateRoot(Column column)
        {
            return new StringFilterTreeRoot(column.Name);
        }

        public IEnumerable<FilterTreeNode> CreateChildren(StringFilterTreeNode node)
        {
            throw new NotImplementedException();
        }
    }
}

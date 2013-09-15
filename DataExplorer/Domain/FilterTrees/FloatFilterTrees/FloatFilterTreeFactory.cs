using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees.FloatFilterTrees
{
    public class FloatFilterTreeFactory : IFloatFilterTreeFactory
    {
        public FilterTreeNode CreateRoot(Column column)
        {
            return new FloatFilterTreeRoot(column.Name);
        }

        public IEnumerable<FilterTreeNode> CreateChildren(FloatFilterTreeNode node)
        {
            throw new NotImplementedException();
        }
    }
}

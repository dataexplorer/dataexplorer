using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees.FloatFilterTrees
{
    public interface IFloatFilterTreeFactory
    {
        FilterTreeNode CreateRoot(Column column);

        IEnumerable<FilterTreeNode> CreateChildren(FloatFilterTreeNode node);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees.BooleanFilterTrees
{
    public interface IBooleanFilterTreeFactory
    {
        FilterTreeNode CreateRoot(Column column);
    }
}

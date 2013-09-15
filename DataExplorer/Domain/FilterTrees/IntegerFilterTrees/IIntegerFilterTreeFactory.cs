using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees.IntegerFilterTrees
{
    public interface IIntegerFilterTreeFactory
    {
        FilterTreeNode CreateRoot(Column column);
    }
}

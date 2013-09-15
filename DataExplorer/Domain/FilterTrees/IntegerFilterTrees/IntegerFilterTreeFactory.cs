using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees.IntegerFilterTrees
{
    public class IntegerFilterTreeFactory : IIntegerFilterTreeFactory
    {
        public FilterTreeNode CreateRoot(Column column)
        {
            return new IntegerFilterTreeRoot(column.Name);
        }
    }
}

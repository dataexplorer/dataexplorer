using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees.DateTimeFilterTrees
{
    public class DateTimeFilterTreeFactory : IDateTimeFilterTreeFactory
    {
        public FilterTreeNode CreateRoot(Column column)
        {
            return new DateTimeFilterTreeRoot(column.Name);
        }

        public IEnumerable<FilterTreeNode> CreateChildren(DateTimeFilterTreeNode node)
        {
            throw new NotImplementedException();
        }
    }
}

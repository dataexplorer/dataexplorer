using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees.DateTimeFilterTrees
{
    public class DateTimeFilterTreeRoot : DateTimeFilterTreeNode
    {
        public DateTimeFilterTreeRoot(string name, Column column) 
            : base(name, column)
        {
        }
    }
}

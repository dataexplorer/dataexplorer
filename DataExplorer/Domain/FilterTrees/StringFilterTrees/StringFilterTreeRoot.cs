using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees.StringFilterTrees
{
    public class StringFilterTreeRoot : StringFilterTreeNode
    {
        public StringFilterTreeRoot(string name, Column column) 
            : base(name, column)
        {
        }
    }
}

using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees.BooleanFilterTrees
{
    public class BooleanFilterTreeRoot : BooleanFilterTreeNode
    {
        public BooleanFilterTreeRoot(string name, Column column) 
            : base(name, column)
        {
            
        }
    }
}

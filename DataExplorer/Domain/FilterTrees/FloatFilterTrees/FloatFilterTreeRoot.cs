using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees.FloatFilterTrees
{
    public class FloatFilterTreeRoot : FloatFilterTreeNode
    {
        public FloatFilterTreeRoot(string name, Column column) : base(name, column)
        {
        }
    }
}

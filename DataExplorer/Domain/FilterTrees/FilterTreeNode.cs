using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees
{
    public abstract class FilterTreeNode
    {
        protected readonly string _name;
        protected readonly Column _column;

        public FilterTreeNode(string name, Column column)
        {
            _name = name;
            _column = column;
        }

        public string Name
        {
            get { return _name; }
        }

        public Column Column
        {
            get { return _column; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees;

namespace DataExplorer.Tests.Presentation.Panes.Navigation.NavigationTree
{
    public class FakeFilterTreeNode : FilterTreeNode
    {
        public FakeFilterTreeNode() : base(null, null)
        {
            
        }

        public FakeFilterTreeNode(string name, Column column) : base(name, column)
        {
        }
    }
}

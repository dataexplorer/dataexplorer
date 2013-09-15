using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.FilterTrees;

namespace DataExplorer.Tests.Presentation.Panes.Navigation.NavigationTree
{
    public class FakeFilterTreeNode : FilterTreeNode
    {
        public FakeFilterTreeNode()
        {
            
        }

        public FakeFilterTreeNode(string name)
        {
            _name = name;
        }
    }
}

using System;
using System.Collections.Generic;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees;
using DataExplorer.Domain.Filters;
using DataExplorer.Tests.Domain.Filters;

namespace DataExplorer.Tests.Application.FilterTrees
{
    public class FakeFilterTreeNode : FilterTreeNode
    {
        private readonly Filter _filter;

        public FakeFilterTreeNode() : base(null, null)
        {
            
        }

        public FakeFilterTreeNode(string name, Column column) : base(name, column)
        {
        }

        public FakeFilterTreeNode(FakeFilter filter) : base(null, null)
        {
            _filter = filter;
        }

        public override IEnumerable<FilterTreeNode> CreateChildren()
        {
            throw new NotImplementedException();
        }

        public override Filter CreateFilter()
        {
            return _filter;
        }
    }
}

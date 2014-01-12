using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.FilterTrees;

namespace DataExplorer.Application.FilterTrees.Commands
{
    public interface ISelectFilterTreeNodeCommand
    {
        void Execute(FilterTreeNode node);
    }
}

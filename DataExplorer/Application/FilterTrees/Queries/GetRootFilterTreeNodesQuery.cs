using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees;

namespace DataExplorer.Application.FilterTrees.Tasks
{
    public class GetRootFilterTreeNodesQuery : IGetRootFilterTreeNodesQuery
    {
        private readonly IColumnRepository _repository;
        private readonly IFilterTreeNodeFactory _factory;

        public GetRootFilterTreeNodesQuery(
            IColumnRepository repository, 
            IFilterTreeNodeFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public IEnumerable<FilterTreeNode> GetRoots()
        {
            var columns = _repository.GetAll();

            var nodes = columns
                .Select(p => _factory.CreateRoot(p))
                .ToList();

            return nodes;
        }
    }
}

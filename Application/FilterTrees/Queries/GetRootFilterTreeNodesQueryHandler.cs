using System.Collections.Generic;
using System.Linq;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees;

namespace DataExplorer.Application.FilterTrees.Queries
{
    public class GetRootFilterTreeNodesQueryHandler 
        : IQueryHandler<GetRootFilterTreeNodesQuery, List<FilterTreeNode>> 
    {
        private readonly IColumnRepository _repository;
        private readonly IFilterTreeNodeFactory _factory;

        public GetRootFilterTreeNodesQueryHandler(
            IColumnRepository repository, 
            IFilterTreeNodeFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public List<FilterTreeNode> Execute(GetRootFilterTreeNodesQuery query)
        {
            var columns = _repository.GetAll();

            var nodes = columns
                .Select(p => _factory.CreateRoot(p))
                .ToList();

            return nodes;
        }
    }
}

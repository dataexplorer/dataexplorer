using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees;

namespace DataExplorer.Application.FilterTrees
{
    public class FilterTreeService : IFilterTreeService
    {
        private readonly IColumnRepository _repository;
        private readonly IFilterTreeNodeFactory _factory;

        public FilterTreeService(
            IColumnRepository repository,
            IFilterTreeNodeFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public List<FilterTreeNode> GetRoots()
        {
            var columns = _repository.GetAll();

            var nodes = columns
                .Select(p => _factory.CreateRoot(p))
                .ToList();

            return nodes;
        }

        public IEnumerable<FilterTreeNode> GetChildren(FilterTreeNode filterTreeNode)
        {
            throw new NotImplementedException();
        }
    }
}

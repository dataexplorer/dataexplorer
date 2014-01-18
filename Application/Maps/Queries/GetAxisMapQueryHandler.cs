using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Maps;

namespace DataExplorer.Application.Maps.Queries
{
    public class GetAxisMapQueryHandler 
        : IQueryHandler<GetAxisMapQuery, AxisMap>
    {
        private readonly IColumnRepository _repository;
        private readonly IMapFactory _factory;

        public GetAxisMapQueryHandler(
            IColumnRepository repository, 
            IMapFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }
        
        public AxisMap Execute(GetAxisMapQuery query)
        {
            var column = _repository.Get(query.ColumnId);

            var map = _factory.CreateAxisMap(column, query.TargetMin, query.TargetMax);

            return map;
        }
    }
}

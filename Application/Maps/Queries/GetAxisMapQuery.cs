using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Maps;

namespace DataExplorer.Application.Maps.Queries
{
    public class GetAxisMapQuery : IGetAxisMapQuery
    {
        private readonly IColumnRepository _repository;
        private readonly IMapFactory _factory;

        public GetAxisMapQuery(
            IColumnRepository repository, 
            IMapFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }
        
        public IAxisMap Execute(ColumnDto columnDto, double targetMin, double targetMax)
        {
            var column = _repository.Get(columnDto.Id);

            var map = _factory.CreateAxisMap(column, targetMin, targetMax);

            return map;
        }
    }
}

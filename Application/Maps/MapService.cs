using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Maps.Queries;
using DataExplorer.Domain.Maps;

namespace DataExplorer.Application.Maps
{
    public class MapService : IMapService
    {
        private readonly IGetAxisMapQuery _getAxisMapQuery;

        public MapService(IGetAxisMapQuery getAxisMapQuery)
        {
            _getAxisMapQuery = getAxisMapQuery;
        }

        public IAxisMap GetAxisMap(ColumnDto columnDto, double targetMin, double targetMax)
        {
            return _getAxisMapQuery.Execute(columnDto, targetMin, targetMax);
        }
    }
}

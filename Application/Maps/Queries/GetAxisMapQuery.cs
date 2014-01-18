using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Domain.Maps;

namespace DataExplorer.Application.Maps.Queries
{
    public class GetAxisMapQuery : IQuery<AxisMap>
    {
        private readonly int _columnId;
        private readonly double _targetMin;
        private readonly double _targetMax;

        public GetAxisMapQuery(int columnId, double targetMin, double targetMax)
        {
            _columnId = columnId;
            _targetMin = targetMin;
            _targetMax = targetMax;
        }

        public int ColumnId
        {
            get { return _columnId; }
        }

        public double TargetMin
        {
            get { return _targetMin; }
        }

        public double TargetMax
        {
            get { return _targetMax; }
        }
    }
}

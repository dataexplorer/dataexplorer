using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Factories.DateTimeAxisGridLines
{
    public class MinMaxDateTimeAxisGridLineFactory : IMinMaxDateTimeAxisGridLineFactory
    {
        public IEnumerable<AxisGridLine> Create(IAxisMap map)
        {
            yield return CreateAxisGridLine(map, DateTime.MinValue);
            yield return CreateAxisGridLine(map, DateTime.MaxValue);
        }

        // TODO: This is duplicated across multiple classes... must refactor
        private AxisGridLine CreateAxisGridLine(IAxisMap map, DateTime value)
        {
            var position = map.Map(value);

            var line = new AxisGridLine()
            {
                Position = position.GetValueOrDefault()
            };

            return line;
        }
    }
}

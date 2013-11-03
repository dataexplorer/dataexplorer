using System;
using System.Collections.Generic;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisGrid.Factories.DateTimeAxisGridLines
{
    public class MinMaxDateTimeAxisGridLineFactory : IMinMaxDateTimeAxisGridLineFactory
    {
        public IEnumerable<AxisGridLine> Create(IAxisMap map)
        {
            yield return CreateAxisGridLine(map, DateTime.MinValue, "0001");
            yield return CreateAxisGridLine(map, DateTime.MaxValue, "10000");
        }

        // TODO: This is duplicated across multiple classes... must refactor
        private AxisGridLine CreateAxisGridLine(IAxisMap map, DateTime value, string label)
        {
            var position = map.Map(value);

            var line = new AxisGridLine()
            {
                LabelName = label,
                Position = position.GetValueOrDefault()
            };

            return line;
        }
    }
}

using System;
using System.Collections.Generic;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots.Axes.Factories.DateTimeGridLines
{
    public class MinMaxDateTimeAxisGridLineFactory : IMinMaxDateTimeAxisGridLineFactory
    {
        public IEnumerable<AxisGridLine> Create(AxisMap map)
        {
            yield return CreateAxisGridLine(map, DateTime.MinValue, "0001");
            yield return CreateAxisGridLine(map, DateTime.MaxValue, "10000");
        }

        // TODO: This is duplicated across multiple classes... must refactor
        private AxisGridLine CreateAxisGridLine(AxisMap map, DateTime value, string label)
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

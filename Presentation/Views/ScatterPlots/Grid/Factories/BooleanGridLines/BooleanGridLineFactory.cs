using System.Collections.Generic;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.Grid.Factories.BooleanGridLines
{
    public class BooleanGridLineFactory : IBooleanGridLineFactory
    {
        public IEnumerable<AxisGridLine> Create(IAxisMap map, double lower, double upper)
        {
            yield return CreateAxisLine(map, false);

            yield return CreateAxisLine(map, true);
        }

        private static AxisGridLine CreateAxisLine(IAxisMap map, bool value)
        {
            var location = map.Map(value);

            var line = new AxisGridLine()
            {
                LabelName = value.ToString(),
                Position = location ?? 0d
            };

            return line;
        }
    }
}

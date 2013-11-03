using System.Collections.Generic;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Factories.BooleanAxisGridLines
{
    public class BooleanAxisGridLineFactory : IBooleanAxisGridLineFactory
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
                Position = location ?? 0d
            };

            return line;
        }
    }
}

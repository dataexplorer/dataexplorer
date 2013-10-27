using System.Collections.Generic;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Factories.BooleanAxisGridLines
{
    public class BooleanAxisGridLineFactory : IBooleanAxisGridLineFactory
    {
        public IEnumerable<AxisLine> Create(IAxisMap map)
        {
            yield return CreateAxisLine(map, false);

            yield return CreateAxisLine(map, true);
        }

        private static AxisLine CreateAxisLine(IAxisMap map, bool value)
        {
            var location = map.Map(value);

            var line = new AxisLine()
            {
                Position = location ?? 0d
            };

            return line;
        }
    }
}

using System.Collections.Generic;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.Grid.Factories.IntegerGridLines
{
    public class IntegerGridLineFactory : IIntegerGridLineFactory
    {
        public IEnumerable<AxisGridLine> Create(AxisMap map, double lower, double upper)
        {
            var lowerInt = (int) map.MapInverse(lower);

            var upperInt = (int) map.MapInverse(upper);

            var width = (double) upperInt - lowerInt;

            if (lowerInt == int.MinValue)
                yield return CreateAxisGridLine(map, lowerInt);

            if (upperInt == int.MaxValue)
                yield return CreateAxisGridLine(map, upperInt);

            var step = 0d;
            var start = 0d;
            for (var i = 1d; i < int.MaxValue; i *= 10)
            {
                if (width >= i && width < i * 15)
                {
                    step = i;
                    start = (int) (lowerInt - (lowerInt % i));
                    break;
                }
            }

            if (step == 0d)
                yield break;

            for (var i = start; i <= upperInt; i += step)
                yield return CreateAxisGridLine(map, (int) i);
        }

        private AxisGridLine CreateAxisGridLine(AxisMap map, int value)
        {
            var line = new AxisGridLine()
            {
                Position = GetPosition(map, value),
                LabelName = GetLabelName(value)
            };

            return line;
        }

        private double GetPosition(AxisMap map, int value)
        {
            return map.Map(value).GetValueOrDefault();
        }

        private string GetLabelName(int value)
        {
            if (value <= -1000000 || value >= 1000000)
                return value.ToString("E2");
            
            return value.ToString();
        }
    }
}

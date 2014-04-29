using System;
using System.Collections.Generic;
using System.Linq;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots.Axes.Factories.StringGridLines
{
    public class StringGridLineFactory : IStringGridLineFactory
    {
        private const int AlphaGroupMin = 10;
        private const char StartChar = (char) 32;
        private const char EndChar = (char) 96;

        public IEnumerable<AxisGridLine> Create(AxisMap map, List<object> values,  double lower, double upper)
        {
            var count = values
                .Select(map.Map)
                .Count(p => p >= lower 
                    && p <= upper);

            return (count <= AlphaGroupMin)
                ? CreateValueGridLines(map, values, lower, upper)
                : CreateAlphaGridLines(map, values.Cast<string>().ToList(), lower, upper);
        }

        private IEnumerable<AxisGridLine> CreateValueGridLines(AxisMap map, List<object> values, double lower, double upper)
        {
            if (map.SortOrder == SortOrder.Descending)
                values.Reverse();

            foreach (var value in values)
            {
                var location = map.Map(value).GetValueOrDefault();

                if (location >= lower && location <= upper)
                    yield return CreateAxisGridLine(location, value.ToString());
            }
        }

        private IEnumerable<AxisGridLine> CreateAlphaGridLines(AxisMap map, List<string> values, double lower, double upper)
        {
            var lowerString = map.SortOrder == SortOrder.Ascending
                ? (string) map.MapInverse(lower)
                : (string) map.MapInverse(upper);

            var upperString = map.SortOrder == SortOrder.Ascending
                ? (string) map.MapInverse(upper)
                : (string) map.MapInverse(lower);

            var lowerChar = IsFirstCharacterValid(lowerString) 
                ? lowerString[0]
                : StartChar;

            var upperChar = IsFirstCharacterValid(upperString)
                ? upperString[0]
                : EndChar;

            for (var c = lowerChar; c <= upperChar; c++)
            {
                var first = values.Where(p => p != string.Empty)
                    .FirstOrDefault(p => p[0].ToString().ToUpper() == c.ToString().ToUpper());

                if (first != null)
                    yield return CreateAxisGridLine(map.Map(first).GetValueOrDefault(), c.ToString().ToUpper());
            }
        }

        private static bool IsFirstCharacterValid(string lowerString)
        {
            return lowerString != string.Empty 
                && Char.IsLetter(lowerString[0]);
        }

        private AxisGridLine CreateAxisGridLine(double position, string label)
        {
            return new AxisGridLine()
            {
                Position = position,
                LabelName = label
            };
        }
    }
}

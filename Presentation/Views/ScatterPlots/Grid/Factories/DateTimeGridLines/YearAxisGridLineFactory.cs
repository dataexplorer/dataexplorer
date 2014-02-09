using System;
using System.Collections.Generic;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.Grid.Factories.DateTimeGridLines
{
    public class YearAxisGridLineFactory : IYearAxisGridLineFactory
    {
        public IEnumerable<AxisGridLine> Create(AxisMap map, DateTime lower, DateTime upper, int step)
        {
            var startYear = GetFirstYearOfGroup(lower, step);

            var endYear = GetFirstYearOfGroup(upper, step);

            if (step == 1000)
                endYear += 1000;

            for (var year = startYear; year <= endYear; year += step)
                yield return CreateAxisGridLine(map, GetDateFromYear(year));
        }

        private static int GetFirstYearOfGroup(DateTime dateTime, int step)
        {
            return dateTime.Year - dateTime.Year % step;
        }

        private static DateTime GetDateFromYear(int year)
        {
            if (year < 1)
                return DateTime.MinValue;

            if (year >= 10000)
                return DateTime.MaxValue;

            return new DateTime(year, 1, 1);
        }

        // TODO: This is duplicated across multiple classes... must refactor
        private static AxisGridLine CreateAxisGridLine(AxisMap map, DateTime value)
        {
            var position = map.Map(value);

            var line = new AxisGridLine()
            {
                LabelName = GetLabel(value),
                Position = position.GetValueOrDefault()
            };

            return line;
        }

        private static string GetLabel(DateTime value)
        {
            return value.Year.ToString().PadLeft(4, '0');
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Factories.DateTimeAxisGridLines
{
    public class YearAxisGridLineFactory : IYearAxisGridLineFactory
    {
        public IEnumerable<AxisGridLine> Create(IAxisMap map, DateTime lower, DateTime upper, int step)
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
        private static AxisGridLine CreateAxisGridLine(IAxisMap map, DateTime value)
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

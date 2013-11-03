using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Factories.DateTimeAxisGridLines
{
    public class DayAxisGridLineFactory : IDayAxisGridLineFactory
    {
        public IEnumerable<AxisGridLine> CreateQuarters(IAxisMap map, DateTime lower, DateTime upper)
        {
            var startDate = GetFirstDayOfQuarter(lower);

            var endDate = GetFirstDayOfQuarter(upper).AddMonths(3);

            for (var date = startDate; date <= endDate; date = date.AddMonths(3))
                yield return CreateAxisGridLine(map, date);
        }

        public IEnumerable<AxisGridLine> CreateMonths(IAxisMap map, DateTime lower, DateTime upper)
        {
            var startDate = new DateTime(lower.Year, lower.Month, 1);

            var endDate = new DateTime(upper.Year, upper.Month, 1).AddMonths(1);

            for (var date = startDate; date <= endDate; date = date.AddMonths(1))
                yield return CreateAxisGridLine(map, date);
        }

        public IEnumerable<AxisGridLine> CreateWeeks(IAxisMap map, DateTime lower, DateTime upper)
        {
            var startDate = GetFirstDayOfWeek(lower).Date;

            var endDate = GetFirstDayOfWeek(upper).AddDays(7).Date;

            for (var date = startDate; date <= endDate; date = date.AddDays(7))
                yield return CreateAxisGridLine(map, date);
        }

        public IEnumerable<AxisGridLine> CreateDays(IAxisMap map, DateTime lower, DateTime upper)
        {
            var startDate = new DateTime(lower.Year, lower.Month, lower.Day);

            var endDate = new DateTime(upper.Year, upper.Month, upper.Day);//.AddDays(1);

            for (var date = startDate; date <= endDate; date = date.AddDays(1))
                yield return CreateAxisGridLine(map, date);
        }

        private static DateTime GetFirstDayOfQuarter(DateTime dateTime)
        {
            if (dateTime.Month <= 3)
                return new DateTime(dateTime.Year, 1, 1);

            if (dateTime.Month <= 6)
                return new DateTime(dateTime.Year, 3, 1);

            if (dateTime.Month <= 9)
                return new DateTime(dateTime.Year, 6, 1);

            if (dateTime.Month <= 12)
                return new DateTime(dateTime.Year, 9, 1);

            throw new ArgumentException("Month does not match any case in switch statement.");
        }

        private static DateTime GetFirstDayOfWeek(DateTime dateTime)
        {
            return dateTime.AddDays(DayOfWeek.Monday - dateTime.DayOfWeek);
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

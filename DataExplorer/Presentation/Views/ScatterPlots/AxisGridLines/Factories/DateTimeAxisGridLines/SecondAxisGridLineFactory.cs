using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Factories.DateTimeAxisGridLines
{
    public class SecondAxisGridLineFactory : ISecondAxisGridLineFactory
    {
        private const int SecondsInDay = 86400;
        private const int SecondsInQuarterDay = 21600;
        private const int SecondsInHour = 3600;
        private const int SecondsInQuarterHour = 900;
        private const int SecondsInMinute = 60;
        private const int SecondsInQuarterMinute = 15;

        public IEnumerable<AxisGridLine> CreateFourHours(IAxisMap map, DateTime lower, DateTime upper)
        {
            var startTime = lower.Date;

            var endTime = upper;

            for (var date = startTime; date <= endTime; date = date.AddHours(4))
                yield return CreateAxisGridLine(map, date);
        }

        public IEnumerable<AxisGridLine> CreateHours(IAxisMap map, DateTime lower, DateTime upper)
        {
            var startTime = lower.Date.AddHours(lower.Hour);

            var endTime = upper;

            for (var date = startTime; date <= endTime; date = date.AddHours(1))
                yield return CreateAxisGridLine(map, date);
        }

        public IEnumerable<AxisGridLine> CreateTenMinutes(IAxisMap map, DateTime lower, DateTime upper)
        {
            var startTime = lower.Date.AddHours(lower.Hour);

            var endTime = upper;

            for (var date = startTime; date <= endTime; date = date.AddMinutes(10))
                yield return CreateAxisGridLine(map, date);
        }

        public IEnumerable<AxisGridLine> CreateMinutes(IAxisMap map, DateTime lower, DateTime upper)
        {
            var startTime = lower.Date
                .AddHours(lower.Hour)
                .AddMinutes(lower.Minute);

            var endTime = upper;

            for (var date = startTime; date <= endTime; date = date.AddMinutes(1))
                yield return CreateAxisGridLine(map, date);
        }

        public IEnumerable<AxisGridLine> CreateTenSeconds(IAxisMap map, DateTime lower, DateTime upper)
        {
            var startTime = lower.Date
                .AddHours(lower.Hour)
                .AddMinutes(lower.Minute);

            var endTime = upper;

            for (var date = startTime; date <= endTime; date = date.AddSeconds(10))
                yield return CreateAxisGridLine(map, date);
        }

        public IEnumerable<AxisGridLine> CreateSeconds(IAxisMap map, DateTime lower, DateTime upper)
        {
            var startTime = lower.Date
                .AddHours(lower.Hour)
                .AddMinutes(lower.Minute)
                .AddSeconds(lower.Second);

            var endTime = upper;

            for (var date = startTime; date <= endTime; date = date.AddSeconds(1))
                yield return CreateAxisGridLine(map, date);
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

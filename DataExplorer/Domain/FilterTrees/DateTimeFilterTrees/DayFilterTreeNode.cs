using System;
using System.Collections.Generic;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees.DateTimeFilterTrees
{
    public class DayFilterTreeNode : DateTimeFilterTreeNode
    {
        public DayFilterTreeNode(string name, Column column, DateTime lower, DateTime upper) 
            : base(name, column, lower, upper)
        {
        }

        public override IEnumerable<FilterTreeNode> CreateChildren()
        {
            var children = new List<FilterTreeNode>();

            var year = _lower.Year;

            var month = _lower.Month;

            var day = _lower.Day;

            var lowerHour = _lower.Hour;

            var upperHour = _upper.Hour;

            for (var i = lowerHour; i <= upperHour; i++)
            {
                var lowerDateTime = CreateLowerDateTime(year, month, day, i);

                var upperDateTime = CreateUpperDateTime(year, month, day, i);

                if (!HasValuesInRange(lowerDateTime, upperDateTime))
                    continue;

                var name = CreateName(lowerDateTime);

                var child = new HourFilterTreeNode(name, _column, lowerDateTime, upperDateTime);

                children.Add(child);
            }

            return children;
        }

        private DateTime CreateLowerDateTime(int year, int month, int day, int hour)
        {
            return (year == 1 && month == 1 && day == 1 && hour == 0)
                ? DateTime.MinValue
                : new DateTime(year, month, day, hour, 0, 0);
        }

        private DateTime CreateUpperDateTime(int year, int month, int day, int hour)
        {
            return (year == 9999 && month == 12 && day == 31 && hour == 23)
               ? DateTime.MaxValue
               : new DateTime(year, month, day, hour, 0, 0)
                    .AddHours(1)
                    .AddTicks(-1);
        }

        private static string CreateName(DateTime dateTime)
        {
            return dateTime.ToString("h tt");
        }
    }
}

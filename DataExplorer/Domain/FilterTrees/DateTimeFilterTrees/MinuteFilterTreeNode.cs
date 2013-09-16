using System;
using System.Collections.Generic;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees.DateTimeFilterTrees
{
    public class MinuteFilterTreeNode : DateTimeFilterTreeNode
    {
        public MinuteFilterTreeNode(string name, Column column, DateTime lower, DateTime upper) 
            : base(name, column, lower, upper)
        {
        }

        public override IEnumerable<FilterTreeNode> CreateChildren()
        {
            var children = new List<FilterTreeNode>();

            var year = _lower.Year;

            var month = _lower.Month;

            var day = _lower.Day;

            var hour = _lower.Hour;

            var minute = _lower.Minute;

            var lowerSecond = _lower.Second;

            var upperSecond = _upper.Second;

            for (var i = lowerSecond; i <= upperSecond; i++)
            {
                var lowerDateTime = CreateLowerDateTime(year, month, day, hour, minute, i);

                var upperDateTime = CreateUpperDateTime(year, month, day, hour, minute, i);

                if (!HasValuesInRange(lowerDateTime, upperDateTime))
                    continue;

                var name = CreateName(lowerDateTime);

                var child = new SecondFilterTreeNode(name, _column, lowerDateTime, upperDateTime);

                children.Add(child);
            }

            return children;
        }

        private DateTime CreateLowerDateTime(int year, int month, int day, int hour, int minute, int second)
        {
            return (year == 1 && month == 1 && day == 1
                    && hour == 0 && minute == 0 && second == 0)
                ? DateTime.MinValue
                : new DateTime(year, month, day, hour, minute, second);
        }

        private DateTime CreateUpperDateTime(int year, int month, int day, int hour, int minute, int second)
        {
            return (year == 9999 && month == 12 && day == 31
                    && hour == 23 && minute == 59 && minute == 59)
               ? DateTime.MaxValue
               : new DateTime(year, month, day, hour, minute, second)
                    .AddSeconds(1)
                    .AddTicks(-1);
        }

        private static string CreateName(DateTime dateTime)
        {
            return dateTime.ToString("hh:mm:ss");
        }
    }
}

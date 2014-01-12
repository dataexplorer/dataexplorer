using System;
using System.Collections.Generic;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees.DateTimeFilterTrees
{
    public class YearFilterTreeNode : DateTimeFilterTreeNode
    {
        public YearFilterTreeNode(string name, Column column, DateTime upper, DateTime lower) 
            : base(name, column, upper, lower)
        {
        }

        public override IEnumerable<FilterTreeNode> CreateChildren()
        {
            var year = _lower.Year;

            var lowerMonth = _lower.Month;

            var upperMonth = _upper.Month;

            for (var i = lowerMonth; i <= upperMonth; i++)
            {
                var lowerDateTime = CreateLowerDateTime(year, i);

                var upperDateTime = CreateUpperDateTime(year, i);

                if (!HasValuesInRange(lowerDateTime, upperDateTime))
                    continue;

                var name = CreateName(lowerDateTime);

                var child = new MonthFilterTreeNode(name, _column, lowerDateTime, upperDateTime);

                yield return child;
            }
        }

        private DateTime CreateLowerDateTime(int year, int month)
        {
            return (year == 1 && month == 1)
                ? DateTime.MinValue
                : new DateTime(year, month, 1);
        }

        private DateTime CreateUpperDateTime(int year, int month)
        {
            return (year == 9999 && month == 12)
               ? DateTime.MaxValue
               : new DateTime(year, month, 1)
                    .AddMonths(1)
                    .AddTicks(-1);
        }

        private static string CreateName(DateTime dateTime)
        {
            return dateTime.ToString("MMM");
        }
    }
}

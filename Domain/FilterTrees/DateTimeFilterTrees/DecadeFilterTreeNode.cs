using System;
using System.Collections.Generic;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Domain.FilterTrees.DateTimeFilterTrees
{
    public class DecadeFilterTreeNode : DateTimeFilterTreeNode
    {      
        public DecadeFilterTreeNode(string name, Column column, DateTime lower, DateTime upper) 
            : base(name, column, lower, upper)
        {
        }

        public override IEnumerable<FilterTreeNode> CreateChildren()
        {          
            var lowerYear = _lower.Year;

            var upperYear = _upper.Year;

            for (var i = lowerYear; i <= upperYear; i++)
            {
                var lowerDateTime = CreateLowerDateTime(i);

                var upperDateTime = CreateUpperDateTime(i);

                if (!HasValuesInRange(lowerDateTime, upperDateTime))
                    continue;

                var name = CreateName(i);

                var child = new YearFilterTreeNode(name, _column, lowerDateTime, upperDateTime);

                yield return child;
            }
        }

        private DateTime CreateLowerDateTime(int year)
        {
            return (year == 0)
                ? DateTime.MinValue
                : new DateTime(year, 1, 1);
        }

        private DateTime CreateUpperDateTime(int year)
        {
            return (year == 9999)
               ? DateTime.MaxValue
               : new DateTime(year + 1, 1, 1).AddTicks(-1);
        }

        private static string CreateName(int i)
        {
            return i.ToString();
        }
    }
}

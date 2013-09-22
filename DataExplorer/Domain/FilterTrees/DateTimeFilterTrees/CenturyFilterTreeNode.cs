using System;
using System.Collections.Generic;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Domain.FilterTrees.DateTimeFilterTrees
{
    public class CenturyFilterTreeNode : DateTimeFilterTreeNode
    {
        public CenturyFilterTreeNode(string name, Column column, DateTime lower, DateTime upper)
            : base(name, column, lower, upper)
        {
        }

        public override IEnumerable<FilterTreeNode> CreateChildren()
        {
            var lowerDecade = GetDecade(_lower);

            var upperDecade = GetDecade(_upper);

            for (var i = lowerDecade; i <= upperDecade; i++)
            {
                var lowerDateTime = CreateLowerDateTime(i);

                var upperDateTime = CreateUpperDateTime(i);

                if (!HasValuesInRange(lowerDateTime, upperDateTime))
                    continue;

                var name = CreateName(i);

                var child = new DecadeFilterTreeNode(name, _column, lowerDateTime, upperDateTime);

                yield return child;
            }
        }

        private static int GetDecade(DateTime dateTime)
        {
            return (dateTime.Year / 10);
        }

        private DateTime CreateLowerDateTime(int decade)
        {
            return (decade == 0)
                ? DateTime.MinValue
                : new DateTime((decade) * 10, 1, 1);
        }

        private DateTime CreateUpperDateTime(int decade)
        {
            return (decade == 999)
               ? DateTime.MaxValue
               : new DateTime((decade + 1) * 10, 1, 1).AddTicks(-1);
        }
        
        private static string CreateName(int i)
        {
            return i + "0s";
        }
    }
}

using System;
using System.Collections.Generic;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.BooleanFilterTrees;
using DataExplorer.Domain.FilterTrees.DateTimeFilterTrees;
using DataExplorer.Domain.FilterTrees.FloatFilterTrees;
using DataExplorer.Domain.FilterTrees.IntegerFilterTrees;
using DataExplorer.Domain.FilterTrees.StringFilterTrees;

namespace DataExplorer.Domain.FilterTrees
{
    public class FilterTreeFactory : IFilterTreeNodeFactory
    {
        private readonly IBooleanFilterTreeFactory _booleanFactory;
        private readonly IDateTimeFilterTreeFactory _dateTimeFactory;
        private readonly IFloatFilterTreeFactory _floatFactory;
        private readonly IIntegerFilterTreeFactory _integerFactory;
        private readonly IStringFilterTreeFactory _stringFactory;

        public FilterTreeFactory(
            IBooleanFilterTreeFactory booleanFactory,
            IDateTimeFilterTreeFactory dateTimeFactory,
            IFloatFilterTreeFactory floatFactory,
            IIntegerFilterTreeFactory integerFactory,
            IStringFilterTreeFactory stringFactory)
        {
            _booleanFactory = booleanFactory;
            _dateTimeFactory = dateTimeFactory;
            _floatFactory = floatFactory;
            _integerFactory = integerFactory;
            _stringFactory = stringFactory;
        }

        public FilterTreeNode CreateRoot(Column column)
        {
            if (column.Type == typeof(Boolean))
                return _booleanFactory.CreateRoot(column);

            if (column.Type == typeof(DateTime))
                return _dateTimeFactory.CreateRoot(column);

            if (column.Type == typeof(Double))
                return _floatFactory.CreateRoot(column);

            if (column.Type == typeof(Int32))
                return _integerFactory.CreateRoot(column);

            if (column.Type == typeof(String))
                return _stringFactory.CreateRoot(column);

            throw new ArgumentException("Column data type is not recognized.");
        }

        public IEnumerable<FilterTreeNode> CreateChildren(FilterTreeNode node)
        {
            if (node is BooleanFilterTreeNode)
                return _booleanFactory.CreateChildren((BooleanFilterTreeNode) node);

            if (node is DateTimeFilterTreeNode)
                return _dateTimeFactory.CreateChildren((DateTimeFilterTreeNode) node);

            if (node is FloatFilterTreeNode)
                return _floatFactory.CreateChildren((FloatFilterTreeNode) node);

            if (node is IntegerFilterTreeNode)
                return _integerFactory.CreateChildren((IntegerFilterTreeNode) node);

            if (node is StringFilterTreeNode)
                return _stringFactory.CreateChildren((StringFilterTreeNode) node);
            
            throw new ArgumentException("Filter node type not recognized.");
        }
    }
}

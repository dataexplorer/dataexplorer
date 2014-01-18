using System;
using System.Windows;
using System.Windows.Controls;
using DataExplorer.Presentation.Panes.Filter.BooleanFilters;

namespace DataExplorer.Presentation.Panes.Filter
{
    public class FilterDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate BooleanFilterDataTemplate { get; set; }
        public DataTemplate DateRangeFilterDataTemplate { get; set; }
        public DataTemplate IntegerRangeFilterDataTemplate { get; set; }
        public DataTemplate FloatRangeFilterDataTemplate { get; set; }
        public DataTemplate NotNullFilterDataTemplate { get; set; }
        public DataTemplate NullFilterDataTemplate { get; set; }
        public DataTemplate StringFilterDataTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is BooleanFilterViewModel)
                return BooleanFilterDataTemplate;

            //if (item is DateRangeFilterViewModel)
            //    return DateRangeFilterDataTemplate;

            //if (item is IntegerRangeFilterViewModel)
            //    return IntegerRangeFilterDataTemplate;

            //if (item is FloatRangeFilterViewModel)
            //    return FloatRangeFilterDataTemplate;

            ////if (item is NotNullFilterViewModel)
            ////    return NotNullFilterDataTemplate;

            //if (item is NullFilterViewModel)
            //    return NullFilterDataTemplate;

            //if (item is StringFilterViewModel)
            //    return StringFilterDataTemplate;

            return base.SelectTemplate(item, container);
        }
    }
}

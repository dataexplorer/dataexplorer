using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Filters.Commands;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Presentation.Panes.Filter.IntegerFilters
{
    public class IntegerRangeFilterViewModel : FilterViewModel
    {
        private readonly IntegerFilter _filter;

        public IntegerRangeFilterViewModel(
            ICommandBus commandBus, 
            IntegerFilter filter) 
            : base(commandBus, filter)
        {
            _filter = filter;
        }

        public int LowerValue
        {
            get { return _filter.LowerValue; }
            set
            {
                _filter.LowerValue = value;
                OnPropertyChanged(() => LowerValue);
                OnPropertyChanged(() => LowerSliderValue);
                _commandBus.Execute(new UpdateFilterCommand(_filter));
            }
        }

        public int UpperValue
        {
            get { return _filter.UpperValue; }
            set
            {
                _filter.UpperValue = value;
                OnPropertyChanged(() => UpperValue);
                OnPropertyChanged(() => UpperSliderValue);
                _commandBus.Execute(new UpdateFilterCommand(_filter));
            }
        }

        public double MinSliderValue
        {
            get { return 0.0d; }
        }

        public double MaxSliderValue
        {
            get { return 1.0d; }
        }

        public double LowerSliderValue
        {
            get { return CalculateSliderValue(_filter.LowerValue); }
            set
            {
                _filter.LowerValue = CalculateFilterValue(value);
                OnPropertyChanged(() => LowerValue);
                OnPropertyChanged(() => LowerSliderValue);
                _commandBus.Execute(new UpdateFilterCommand(_filter));
            }
        }

        public double UpperSliderValue
        {
            get { return CalculateSliderValue(_filter.UpperValue); }
            set
            {
                _filter.UpperValue = CalculateFilterValue(value);
                OnPropertyChanged(() => UpperValue);
                OnPropertyChanged(() => UpperSliderValue);
                _commandBus.Execute(new UpdateFilterCommand(_filter));
            }
        }
        
        private double CalculateSliderValue(int filterValue)
        {
            var minValue = (int) _filter.Column.Min;

            var maxValue = (int) _filter.Column.Max;

            var isValue = (filterValue) - minValue;

            var ofValue = maxValue - minValue;

            return (double) isValue / (double) ofValue;
        }

        private int CalculateFilterValue(double sliderValue)
        {
            var minValue = (int) _filter.Column.Min;

            var maxValue = (int) _filter.Column.Max;

            var ofValue = maxValue - minValue;

            var isValue = (int) (ofValue * sliderValue);
            
            return minValue + isValue;
        }
    }
}

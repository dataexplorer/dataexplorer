using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Filters.Commands;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Presentation.Panes.Filter.DateTimeFilters
{
    public class DateRangeFilterViewModel : FilterViewModel
    {
        private readonly DateTimeFilter _filter;

        public DateRangeFilterViewModel(ICommandBus commandBus, DateTimeFilter filter) 
            : base(commandBus, filter)
        {
            _filter = filter;
        }

        public DateTime LowerValue
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

        public DateTime UpperValue
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
        
        private double CalculateSliderValue(DateTime filterValue)
        {
            var minValue = (DateTime) _filter.Column.Min;

            var maxValue = (DateTime) _filter.Column.Max;

            var isValue = filterValue.Subtract(minValue).Ticks;

            var ofValue = maxValue.Subtract(minValue).Ticks;

            return (double) isValue / (double) ofValue;
        }

        private DateTime CalculateFilterValue(double sliderValue)
        {
            var minValue = (DateTime) _filter.Column.Min;

            var maxValue = (DateTime) _filter.Column.Max;

            var ofValue = maxValue.Subtract(minValue).Ticks;

            var isValue = (long) (ofValue * sliderValue);
            
            return minValue.AddTicks(isValue);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Filters.Commands;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Presentation.Panes.Filter.FloatFilters
{
    public class FloatRangeFilterViewModel : FilterViewModel
    {
        private readonly FloatFilter _filter;

        public FloatRangeFilterViewModel(
            ICommandBus commandBus, 
            FloatFilter filter) 
            : base(commandBus, filter)
        {
            _filter = filter;
        }

        public double LowerValue
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

        public double UpperValue
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
        
        private double CalculateSliderValue(double filterValue)
        {
            var minValue = (double) _filter.Column.Min * 0.5d;

            var maxValue = (double) _filter.Column.Max * 0.5d;

            var isValue = (filterValue * 0.5d) - minValue;

            var ofValue = maxValue - minValue;

            return (double) isValue / (double) ofValue;
        }

        private double CalculateFilterValue(double sliderValue)
        {
            var minValue = (double) _filter.Column.Min * 0.5d;

            var maxValue = (double) _filter.Column.Max * 0.5d;

            var ofValue = maxValue - minValue;

            var isValue = ofValue * sliderValue;
            
            return minValue * 2 + isValue * 2;
        }
    }
}

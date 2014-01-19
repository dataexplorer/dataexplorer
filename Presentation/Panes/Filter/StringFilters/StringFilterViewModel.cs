using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Filters.Commands;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Presentation.Panes.Filter.StringFilters
{
    public class StringFilterViewModel : FilterViewModel
    {
        private readonly StringFilter _filter;

        public StringFilterViewModel(
            ICommandBus commandBus, 
            StringFilter filter) 
            : base(commandBus, filter)
        {
            _filter = filter;
        }

        public string Value
        {
            get { return _filter.Value; }
            set
            {
                _filter.Value = value;
                OnPropertyChanged(() => Value);
                _commandBus.Execute(new UpdateFilterCommand(_filter));
            }
        }
    }
}

using System;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Filters.Commands;
using DataExplorer.Presentation.Core.Commands;
using ICommand = System.Windows.Input.ICommand;

namespace DataExplorer.Presentation.Panes.Filter
{
    public abstract class FilterViewModel
    {
        protected readonly ICommandBus _commandBus;
        private readonly Domain.Filters.Filter _filter;
        private readonly ICommand _closeCommand;

        protected FilterViewModel(Domain.Filters.Filter filter, ICommandBus commandBus)
        {
            _filter = filter;
            _commandBus = commandBus;

            _closeCommand = new DelegateCommand(Close);
        }

        public string Label
        {
            get { return _filter.Column.Name; }
        }

        public bool IsIncludeNullVisible
        {
            get { return _filter.Column.HasNulls; }
        }

        public bool IncludeNull
        {
            get { return _filter.IncludeNull; }
            set
            {
                _filter.IncludeNull = value;
                _commandBus.Execute(new UpdateFilterCommand(_filter));
            }
        }

        public Domain.Filters.Filter Filter
        {
            get { return _filter; }
        }

        public System.Windows.Input.ICommand CloseCommand
        {
            get { return _closeCommand; }
        }

        private void Close(object obj)
        {
            _commandBus.Execute(new RemoveFilterCommand(_filter));
        }
    }
}

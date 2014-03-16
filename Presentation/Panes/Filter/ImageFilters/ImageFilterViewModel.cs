using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Filters.Commands;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Presentation.Panes.Filter.ImageFilters
{
    public class ImageFilterViewModel : FilterViewModel
    {
        private readonly ImageFilter _filter;

        public ImageFilterViewModel(ICommandBus commandBus, ImageFilter filter) 
            : base(commandBus, filter)
        {
            _filter = filter;
        }

        public bool IncludeNotNull
        {
            get { return _filter.IncludeNotNull; }
            set
            {
                _filter.IncludeNotNull = value;
                _commandBus.Execute(new UpdateFilterCommand(_filter));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Application.Core.Queries;

namespace DataExplorer.Application.Clipboard.Queries
{
    public class CanCopyDataToClipboardQueryHandler 
        : IQueryHandler<CanCopyDataToClipboardQuery, bool>
    {
        private readonly IApplicationStateService _stateService;

        public CanCopyDataToClipboardQueryHandler(IApplicationStateService stateService)
        {
            _stateService = stateService;
        }

        public bool Execute(CanCopyDataToClipboardQuery query)
        {
            return _stateService.GetSelectedRows().Any();
        }
    }
}
